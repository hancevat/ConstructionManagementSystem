using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace ConstructionManagementSystem.Pages.BuildTaskFlow.Tasks;

public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DetailsModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public BuildTaskFlowTask TaskItem { get; set; } = new();

    [BindProperty]
    [Required(ErrorMessage = "Yorum metni zorunludur.")]
    [StringLength(1200)]
    public string NewCommentText { get; set; } = string.Empty;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var loaded = await LoadTaskAsync(id);
        return loaded ? Page() : NotFound();
    }

    public async Task<IActionResult> OnPostAddCommentAsync(int id)
    {
        if (!CanManageTasks())
        {
            return RedirectToPage("/BuildTaskFlow/AccessDenied");
        }

        var loaded = await LoadTaskAsync(id);
        if (!loaded)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return Page();
        }

        var memberIdValue = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!int.TryParse(memberIdValue, out var memberId) ||
            !await _context.BuildTaskFlowTeamMembers.AnyAsync(member => member.Id == memberId && member.IsActive))
        {
            TempData["ErrorMessage"] = "Yorum eklemek için geçerli bir BuildTaskFlow kullanıcısı gerekir.";
            return RedirectToPage("Details", new { id });
        }

        _context.BuildTaskFlowComments.Add(new BuildTaskFlowComment
        {
            BuildTaskFlowTaskId = id,
            BuildTaskFlowTeamMemberId = memberId,
            Text = NewCommentText.Trim(),
            CreatedAt = DateTime.Now
        });

        await _context.SaveChangesAsync();
        TempData["SuccessMessage"] = "Yorum eklendi.";

        return RedirectToPage("Details", new { id });
    }

    private async Task<bool> LoadTaskAsync(int id)
    {
        var task = await _context.BuildTaskFlowTasks
            .Include(item => item.Project)
            .Include(item => item.Status)
            .Include(item => item.Assignments)
            .ThenInclude(assignment => assignment.TeamMember)
            .Include(item => item.Comments)
            .ThenInclude(comment => comment.TeamMember)
            .FirstOrDefaultAsync(item => item.Id == id);

        if (task is null)
        {
            return false;
        }

        TaskItem = task;
        return true;
    }

    private bool CanManageTasks()
    {
        return BuildTaskFlowPermissions.CanManageTasks(User);
    }
}
