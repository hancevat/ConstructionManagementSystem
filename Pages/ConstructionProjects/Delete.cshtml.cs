using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Pages.ConstructionProjects;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public ConstructionProject ConstructionProject { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var project = await _context.ConstructionProjects
            .Include(item => item.Client)
            .FirstOrDefaultAsync(item => item.Id == id);
        if (project is null)
        {
            return NotFound();
        }

        ConstructionProject = project;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        var project = await _context.ConstructionProjects.FindAsync(id);
        if (project is null)
        {
            return NotFound();
        }

        try
        {
            _context.ConstructionProjects.Remove(project);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Proje kaydı silindi.";
        }
        catch (DbUpdateException)
        {
            TempData["ErrorMessage"] = "Bu proje ilişkili gelir, gider, malzeme alımı veya işçi ödemesi bulunduğu için silinemedi.";
        }

        return RedirectToPage("./Index");
    }
}

