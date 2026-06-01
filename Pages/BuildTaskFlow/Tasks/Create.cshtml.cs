using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Pages.BuildTaskFlow.Tasks;

[Authorize(Roles = BuildTaskFlowRoleNames.TaskEditors)]
public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public BuildTaskFlowTask TaskItem { get; set; } = new();

    [BindProperty]
    public int? AssignedTeamMemberId { get; set; }

    public SelectList ProjectOptions { get; set; } = null!;

    public SelectList StatusOptions { get; set; } = null!;

    public SelectList MemberOptions { get; set; } = null!;

    public string[] PriorityOptions { get; } = ["Düşük", "Orta", "Yüksek", "Acil"];

    public async Task OnGetAsync(int? projectId)
    {
        if (projectId.HasValue)
        {
            TaskItem.BuildTaskFlowProjectId = projectId.Value;
        }

        await LoadOptionsAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await ValidateSelectionsAsync();

        if (!ModelState.IsValid)
        {
            await LoadOptionsAsync();
            return Page();
        }

        var selectedStatus = await _context.BuildTaskFlowTaskStatuses.FindAsync(TaskItem.BuildTaskFlowTaskStatusId);
        if (selectedStatus?.Name == "Tamamlandı")
        {
            TaskItem.CompletedAt = DateTime.Now;
        }

        _context.BuildTaskFlowTasks.Add(TaskItem);
        await _context.SaveChangesAsync();

        if (AssignedTeamMemberId.HasValue)
        {
            _context.BuildTaskFlowTaskAssignments.Add(new BuildTaskFlowTaskAssignment
            {
                BuildTaskFlowTaskId = TaskItem.Id,
                BuildTaskFlowTeamMemberId = AssignedTeamMemberId.Value,
                AssignedAt = DateTime.Now
            });
            await _context.SaveChangesAsync();
        }

        TempData["SuccessMessage"] = "Görev oluşturuldu.";
        return RedirectToPage("Index");
    }

    private async Task ValidateSelectionsAsync()
    {
        if (!await _context.BuildTaskFlowProjects.AnyAsync(project => project.Id == TaskItem.BuildTaskFlowProjectId))
        {
            ModelState.AddModelError("TaskItem.BuildTaskFlowProjectId", "Geçerli bir proje seçin.");
        }

        if (!await _context.BuildTaskFlowTaskStatuses.AnyAsync(status => status.Id == TaskItem.BuildTaskFlowTaskStatusId))
        {
            ModelState.AddModelError("TaskItem.BuildTaskFlowTaskStatusId", "Geçerli bir durum seçin.");
        }

        if (AssignedTeamMemberId.HasValue &&
            !await _context.BuildTaskFlowTeamMembers.AnyAsync(member => member.Id == AssignedTeamMemberId.Value && member.IsActive))
        {
            ModelState.AddModelError(nameof(AssignedTeamMemberId), "Geçerli bir ekip üyesi seçin.");
        }
    }

    private async Task LoadOptionsAsync()
    {
        ProjectOptions = new SelectList(await _context.BuildTaskFlowProjects.OrderBy(project => project.Name).ToListAsync(), "Id", "Name", TaskItem.BuildTaskFlowProjectId);
        StatusOptions = new SelectList(await _context.BuildTaskFlowTaskStatuses.OrderBy(status => status.SortOrder).ToListAsync(), "Id", "Name", TaskItem.BuildTaskFlowTaskStatusId);
        MemberOptions = new SelectList(await _context.BuildTaskFlowTeamMembers.Where(member => member.IsActive).OrderBy(member => member.FullName).ToListAsync(), "Id", "FullName", AssignedTeamMemberId);
    }
}
