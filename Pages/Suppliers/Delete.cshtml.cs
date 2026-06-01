using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Pages.Suppliers;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Supplier Supplier { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var item = await _context.Suppliers.FindAsync(id);
        if (item is null)
        {
            return NotFound();
        }

        Supplier = item;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        var item = await _context.Suppliers.FindAsync(id);
        if (item is null)
        {
            return NotFound();
        }

        try
        {
            _context.Suppliers.Remove(item);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Tedarikçi kaydı silindi.";
        }
        catch (DbUpdateException)
        {
            TempData["ErrorMessage"] = "Bu kayıt ilişkili veriler bulunduğu için silinemedi.";
        }

        return RedirectToPage("./Index");
    }
}

