using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Pages.Materials;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Material Material { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var material = await _context.Materials
            .Include(item => item.MaterialType)
            .FirstOrDefaultAsync(item => item.Id == id);
        if (material is null)
        {
            return NotFound();
        }

        Material = material;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        var material = await _context.Materials.FindAsync(id);
        if (material is null)
        {
            return NotFound();
        }

        try
        {
            _context.Materials.Remove(material);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Malzeme kaydı silindi.";
        }
        catch (DbUpdateException)
        {
            TempData["ErrorMessage"] = "Bu malzeme ilişkili alım kaydı bulunduğu için silinemedi.";
        }

        return RedirectToPage("./Index");
    }
}

