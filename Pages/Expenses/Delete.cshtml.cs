using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Pages.Expenses;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Expense Expense { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var expense = await _context.Expenses
            .Include(item => item.ConstructionProject)
            .FirstOrDefaultAsync(item => item.Id == id);
        if (expense is null)
        {
            return NotFound();
        }

        Expense = expense;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        var expense = await _context.Expenses.FindAsync(id);
        if (expense is null)
        {
            return NotFound();
        }

        _context.Expenses.Remove(expense);
        await _context.SaveChangesAsync();
        TempData["SuccessMessage"] = "Gider kaydı silindi.";

        return RedirectToPage("./Index");
    }
}

