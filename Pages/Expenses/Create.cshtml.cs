using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Pages.Expenses;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Expense Expense { get; set; } = new();

    public SelectList ProjectOptions { get; set; } = null!;

    public SelectList CategoryOptions { get; set; } = null!;

    public async Task OnGetAsync()
    {

        await LoadOptionsAsync();

    }

    public async Task<IActionResult> OnPostAsync()
    {
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

        _context.Expenses.Add(Expense);
        await _context.SaveChangesAsync();
        TempData["SuccessMessage"] = "Gider kaydı oluşturuldu.";

        return RedirectToPage("./Index");
    }

    private async Task LoadOptionsAsync()
    {
        ProjectOptions = new SelectList(await _context.ConstructionProjects.OrderBy(project => project.Name).ToListAsync(), "Id", "Name", Expense.ConstructionProjectId);
        CategoryOptions = new SelectList(ExpenseCategory.All, Expense.Category);
    }
}

