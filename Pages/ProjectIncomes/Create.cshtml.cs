using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Pages.ProjectIncomes;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public ProjectIncome ProjectIncome { get; set; } = new();

    public SelectList ProjectOptions { get; set; } = null!;

    public async Task OnGetAsync()
    {
        await LoadProjectsAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!await _context.ConstructionProjects.AnyAsync(project => project.Id == ProjectIncome.ConstructionProjectId))
        {
            ModelState.AddModelError("ProjectIncome.ConstructionProjectId", "Geçerli bir proje seçin.");
        }

        if (!ModelState.IsValid)
        {
            await LoadProjectsAsync();
            return Page();
        }

        _context.ProjectIncomes.Add(ProjectIncome);
        await _context.SaveChangesAsync();
        TempData["SuccessMessage"] = "Proje geliri kaydedildi.";

        return RedirectToPage("./Index");
    }

    private async Task LoadProjectsAsync()
    {
        ProjectOptions = new SelectList(await _context.ConstructionProjects.OrderBy(project => project.Name).ToListAsync(), "Id", "Name", ProjectIncome.ConstructionProjectId);
    }
}

