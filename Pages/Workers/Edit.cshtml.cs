using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Pages.Workers;

public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Worker Worker { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var item = await _context.Workers.FindAsync(id);
        if (item is null)
        {
            return NotFound();
        }

        Worker = item;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        if (id != Worker.Id)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Worker).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "İşçi kaydı güncellendi.";
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await _context.Workers.AnyAsync(item => item.Id == id))
            {
                return NotFound();
            }

            throw;
        }

        return RedirectToPage("./Index");
    }
}

