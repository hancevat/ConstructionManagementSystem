using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace ConstructionManagementSystem.Pages.BuildTaskFlow.Gantt;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public DateTime TimelineStart { get; set; }

    public DateTime TimelineEnd { get; set; }

    public IList<TimelineMarker> TimelineMarkers { get; set; } = new List<TimelineMarker>();

    public IList<ProjectGanttRow> ProjectRows { get; set; } = new List<ProjectGanttRow>();

    public IList<MemberGanttRow> MemberRows { get; set; } = new List<MemberGanttRow>();

    public int OverallProgress { get; set; }

    public int TotalTasks { get; set; }

    public int CompletedTasks { get; set; }

    public async Task OnGetAsync()
    {
        var projects = await _context.BuildTaskFlowProjects
            .Include(project => project.OwnerTeamMember)
            .Include(project => project.Tasks)
            .ThenInclude(task => task.Status)
            .Include(project => project.Tasks)
            .ThenInclude(task => task.Assignments)
            .ThenInclude(assignment => assignment.TeamMember)
            .OrderBy(project => project.StartDate)
            .ThenBy(project => project.Name)
            .ToListAsync();

        var members = await _context.BuildTaskFlowTeamMembers
            .Include(member => member.Role)
            .Include(member => member.TaskAssignments)
            .ThenInclude(assignment => assignment.Task)
            .ThenInclude(task => task!.Project)
            .Include(member => member.TaskAssignments)
            .ThenInclude(assignment => assignment.Task)
            .ThenInclude(task => task!.Status)
            .Where(member => member.IsActive)
            .OrderBy(member => member.FullName)
            .ToListAsync();

        var allTasks = projects.SelectMany(project => project.Tasks).ToList();
        TotalTasks = allTasks.Count;
        CompletedTasks = allTasks.Count(task => task.Status?.Name == "Tamamlandı" || task.ProgressPercentage >= 100);
        OverallProgress = TotalTasks == 0
            ? 0
            : (int)Math.Round(allTasks.Average(task => task.ProgressPercentage));

        BuildTimeline(projects, allTasks);

        ProjectRows = projects
            .Select(project => BuildProjectRow(project))
            .ToList();

        MemberRows = members
            .Select(BuildMemberRow)
            .Where(member => member.Tasks.Count > 0)
            .ToList();
    }

    private void BuildTimeline(IList<BuildTaskFlowProject> projects, IList<BuildTaskFlowTask> tasks)
    {
        var startCandidates = new List<DateTime>();
        var endCandidates = new List<DateTime>();

        startCandidates.AddRange(projects.Select(project => project.StartDate.Date));
        startCandidates.AddRange(tasks.Select(GetTaskStartDate));

        endCandidates.AddRange(projects.Select(project => (project.EndDate ?? project.StartDate).Date));
        endCandidates.AddRange(tasks.Select(GetTaskEndDate));

        TimelineStart = startCandidates.Count > 0 ? startCandidates.Min() : DateTime.Today.AddDays(-7);
        TimelineEnd = endCandidates.Count > 0 ? endCandidates.Max() : DateTime.Today.AddDays(30);

        if (TimelineEnd <= TimelineStart)
        {
            TimelineEnd = TimelineStart.AddDays(1);
        }

        TimelineStart = TimelineStart.AddDays(-2);
        TimelineEnd = TimelineEnd.AddDays(2);

        var totalDays = GetTimelineTotalDays();
        var markerStep = totalDays <= 45 ? 7 : 14;
        var markers = new List<TimelineMarker>
        {
            new(TimelineStart, TimelineStart.ToString("dd.MM"), "0%")
        };

        var markerDate = TimelineStart.AddDays(markerStep);
        while (markerDate < TimelineEnd)
        {
            markers.Add(new TimelineMarker(markerDate, markerDate.ToString("dd.MM"), ToPercent(markerDate)));
            markerDate = markerDate.AddDays(markerStep);
        }

        markers.Add(new TimelineMarker(TimelineEnd, TimelineEnd.ToString("dd.MM"), "100%"));
        TimelineMarkers = markers;
    }

    private ProjectGanttRow BuildProjectRow(BuildTaskFlowProject project)
    {
        var tasks = project.Tasks
            .OrderBy(GetTaskStartDate)
            .ThenBy(task => task.DueDate ?? DateTime.MaxValue)
            .Select(BuildTaskBar)
            .ToList();

        var projectStart = project.StartDate.Date;
        var projectEnd = (project.EndDate ?? tasks.Select(task => task.EndDate).DefaultIfEmpty(project.StartDate.Date).Max()).Date;
        if (projectEnd < projectStart)
        {
            projectEnd = projectStart;
        }

        var progress = tasks.Count == 0
            ? 0
            : (int)Math.Round(tasks.Average(task => task.ProgressPercentage));

        return new ProjectGanttRow(
            project.Id,
            project.Name,
            project.OwnerTeamMember?.FullName ?? "-",
            project.Status,
            projectStart,
            projectEnd,
            progress,
            ToPercent(projectStart),
            ToWidth(projectStart, projectEnd),
            tasks);
    }

    private MemberGanttRow BuildMemberRow(BuildTaskFlowTeamMember member)
    {
        var tasks = member.TaskAssignments
            .Where(assignment => assignment.Task is not null)
            .Select(assignment => assignment.Task!)
            .DistinctBy(task => task.Id)
            .OrderBy(GetTaskStartDate)
            .ThenBy(task => task.DueDate ?? DateTime.MaxValue)
            .Select(BuildTaskBar)
            .ToList();

        var completed = tasks.Count(task => task.ProgressPercentage >= 100 || task.StatusName == "Tamamlandı");
        var progress = tasks.Count == 0
            ? 0
            : (int)Math.Round(tasks.Average(task => task.ProgressPercentage));

        return new MemberGanttRow(
            member.Id,
            member.FullName,
            member.Role?.Name ?? "-",
            tasks.Count,
            completed,
            progress,
            tasks);
    }

    private TaskGanttBar BuildTaskBar(BuildTaskFlowTask task)
    {
        var startDate = GetTaskStartDate(task);
        var endDate = GetTaskEndDate(task);

        return new TaskGanttBar(
            task.Id,
            task.Title,
            task.Project?.Name ?? "-",
            task.Status?.Name ?? "-",
            task.Priority,
            startDate,
            endDate,
            task.ProgressPercentage,
            string.Join(", ", task.Assignments.Select(assignment => assignment.TeamMember?.FullName).Where(name => !string.IsNullOrWhiteSpace(name))),
            ToPercent(startDate),
            ToWidth(startDate, endDate),
            GetBarCssClass(task));
    }

    private static DateTime GetTaskStartDate(BuildTaskFlowTask task)
    {
        return (task.StartDate ?? task.CreatedAt).Date;
    }

    private static DateTime GetTaskEndDate(BuildTaskFlowTask task)
    {
        var endDate = (task.DueDate ?? task.CompletedAt ?? task.StartDate ?? task.CreatedAt).Date;
        var startDate = GetTaskStartDate(task);
        return endDate < startDate ? startDate : endDate;
    }

    private string ToPercent(DateTime date)
    {
        var offset = Math.Clamp((date.Date - TimelineStart.Date).TotalDays / GetTimelineTotalDays() * 100, 0, 100);
        return string.Create(CultureInfo.InvariantCulture, $"{offset:0.###}%");
    }

    private string ToWidth(DateTime startDate, DateTime endDate)
    {
        var days = Math.Max((endDate.Date - startDate.Date).TotalDays + 1, 1);
        var width = Math.Clamp(days / GetTimelineTotalDays() * 100, 1.5, 100);
        return string.Create(CultureInfo.InvariantCulture, $"{width:0.###}%");
    }

    private double GetTimelineTotalDays()
    {
        return Math.Max((TimelineEnd.Date - TimelineStart.Date).TotalDays + 1, 1);
    }

    private static string GetBarCssClass(BuildTaskFlowTask task)
    {
        if (task.ProgressPercentage >= 100 || task.Status?.Name == "Tamamlandı")
        {
            return "gantt-bar-completed";
        }

        if (task.DueDate.HasValue && task.DueDate.Value.Date < DateTime.Today)
        {
            return "gantt-bar-overdue";
        }

        return task.Status?.Name == "Test Ediliyor" ? "gantt-bar-testing" : "gantt-bar-active";
    }
}

public record TimelineMarker(DateTime Date, string Label, string Left);

public record ProjectGanttRow(
    int Id,
    string Name,
    string OwnerName,
    string Status,
    DateTime StartDate,
    DateTime EndDate,
    int ProgressPercentage,
    string Left,
    string Width,
    IList<TaskGanttBar> Tasks);

public record MemberGanttRow(
    int Id,
    string FullName,
    string RoleName,
    int TotalTasks,
    int CompletedTasks,
    int ProgressPercentage,
    IList<TaskGanttBar> Tasks);

public record TaskGanttBar(
    int Id,
    string Title,
    string ProjectName,
    string StatusName,
    string Priority,
    DateTime StartDate,
    DateTime EndDate,
    int ProgressPercentage,
    string AssignedNames,
    string Left,
    string Width,
    string CssClass);
