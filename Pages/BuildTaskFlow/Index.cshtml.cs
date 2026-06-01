using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Pages.BuildTaskFlow;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public int TotalProjects { get; set; }

    public int TotalTasks { get; set; }

    public int ActiveTasks { get; set; }

    public int CompletedTasks { get; set; }

    public int OverdueTasks { get; set; }

    public int TeamMembers { get; set; }

    public decimal DraftInvoiceTotal { get; set; }

    public IList<BuildTaskFlowTask> RecentTasks { get; set; } = new List<BuildTaskFlowTask>();

    public async Task OnGetAsync()
    {
        var completedStatusId = await _context.BuildTaskFlowTaskStatuses
            .Where(status => status.Name == "Tamamlandı")
            .Select(status => status.Id)
            .FirstOrDefaultAsync();

        TotalProjects = await _context.BuildTaskFlowProjects.CountAsync();
        TotalTasks = await _context.BuildTaskFlowTasks.CountAsync();
        CompletedTasks = await _context.BuildTaskFlowTasks.CountAsync(task => task.BuildTaskFlowTaskStatusId == completedStatusId);
        ActiveTasks = TotalTasks - CompletedTasks;
        OverdueTasks = await _context.BuildTaskFlowTasks.CountAsync(task =>
            task.DueDate.HasValue &&
            task.DueDate.Value.Date < DateTime.Today &&
            task.BuildTaskFlowTaskStatusId != completedStatusId);
        TeamMembers = await _context.BuildTaskFlowTeamMembers.CountAsync(member => member.IsActive);
        DraftInvoiceTotal = await _context.BuildTaskFlowInvoices
            .Where(invoice => invoice.Status == "Taslak")
            .SumAsync(invoice => (decimal?)invoice.GrandTotal) ?? 0m;

        RecentTasks = await _context.BuildTaskFlowTasks
            .Include(task => task.Project)
            .Include(task => task.Status)
            .Include(task => task.Assignments)
            .ThenInclude(assignment => assignment.TeamMember)
            .OrderBy(task => task.DueDate ?? DateTime.MaxValue)
            .ThenByDescending(task => task.CreatedAt)
            .Take(8)
            .ToListAsync();
    }
}
