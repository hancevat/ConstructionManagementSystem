using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Pages.Subcontractors;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Subcontractor Subcontractor { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var item = await _context.Subcontractors.FindAsync(id);
        if (item is null)
        {
            return NotFound();
        }

        Subcontractor = item;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        var item = await _context.Subcontractors.FindAsync(id);
        if (item is null)
        {
            return NotFound();
        }

        try
        {
            _context.Subcontractors.Remove(item);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Taşeron kaydı silindi.";
        }
        catch (DbUpdateException)
        {
            TempData["ErrorMessage"] = "Bu kayıt ilişkili veriler bulunduğu için silinemedi.";
        }

        return RedirectToPage("./Index");
    }
}

