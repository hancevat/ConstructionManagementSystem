using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Pages.BuildTaskFlow.Projects;

[Authorize(Roles = BuildTaskFlowRoleNames.AdminOrProjectManager)]
public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public BuildTaskFlowProject Project { get; set; } = new();

    public SelectList OwnerOptions { get; set; } = null!;

    public string[] StatusOptions { get; } = ["Planlandı", "Devam Ediyor", "Tamamlandı", "Beklemede"];

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var project = await _context.BuildTaskFlowProjects.FindAsync(id);
        if (project is null)
        {
            return NotFound();
        }

        Project = project;
        await LoadOptionsAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (Project.OwnerTeamMemberId.HasValue &&
            !await _context.BuildTaskFlowTeamMembers.AnyAsync(member => member.Id == Project.OwnerTeamMemberId && member.IsActive))
        {
            ModelState.AddModelError("Project.OwnerTeamMemberId", "Geçerli bir proje sorumlusu seçin.");
        }

        if (!ModelState.IsValid)
        {
            await LoadOptionsAsync();
            return Page();
        }

        _context.Attach(Project).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "BuildTaskFlow projesi güncellendi.";
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await _context.BuildTaskFlowProjects.AnyAsync(project => project.Id == Project.Id))
            {
                return NotFound();
            }

            throw;
        }

        return RedirectToPage("Index");
    }

    private async Task LoadOptionsAsync()
    {
        var members = await _context.BuildTaskFlowTeamMembers
            .Where(member => member.IsActive)
            .OrderBy(member => member.FullName)
            .ToListAsync();

        OwnerOptions = new SelectList(members, "Id", "FullName", Project.OwnerTeamMemberId);
    }
}
