using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Pages.Clients;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Client Client { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var item = await _context.Clients.FindAsync(id);
        if (item is null)
        {
            return NotFound();
        }

        Client = item;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        var item = await _context.Clients.FindAsync(id);
        if (item is null)
        {
            return NotFound();
        }

        try
        {
            _context.Clients.Remove(item);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Müşteri kaydı silindi.";
        }
        catch (DbUpdateException)
        {
            TempData["ErrorMessage"] = "Bu kayıt ilişkili veriler bulunduğu için silinemedi.";
        }

        return RedirectToPage("./Index");
    }
}

