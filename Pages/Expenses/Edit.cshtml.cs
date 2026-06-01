using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Pages.Expenses;

public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Expense Expense { get; set; } = null!;

    public SelectList ProjectOptions { get; set; } = null!;

    public SelectList CategoryOptions { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var expense = await _context.Expenses.FindAsync(id);
        if (expense is null)
        {
            return NotFound();
        }

        Expense = expense;

        await LoadOptionsAsync();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        if (id != Expense.Id)
        {
            return NotFound();
        }

        if (!await _context.ConstructionProjects.AnyAsync(project => project.Id == Expense.ConstructionProjectId))
        {
            ModelState.AddModelError("Expense.ConstructionProjectId", "Geçerli bir proje seçin.");
        }

        if (!ExpenseCategory.All.Contains(Expense.Category))
        {
            ModelState.AddModelError("Expense.Category", "Geçerli bir kategori seçin.");
        }

        if (!ModelState.IsValid)
        {
            await LoadOptionsAsync();
            return Page();
        }

        _context.Attach(Expense).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Gider kaydı güncellendi.";
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await _context.Expenses.AnyAsync(expense => expense.Id == id))
            {
                return NotFound();
            }

            throw;
        }

        return RedirectToPage("./Index");
    }

    private async Task LoadOptionsAsync()
    {
        ProjectOptions = new SelectList(await _context.ConstructionProjects.OrderBy(project => project.Name).ToListAsync(), "Id", "Name", Expense.ConstructionProjectId);
        CategoryOptions = new SelectList(ExpenseCategory.All, Expense.Category);
    }
}

