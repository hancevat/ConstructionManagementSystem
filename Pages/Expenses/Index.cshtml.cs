using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Pages.Expenses;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Expense> Expenses { get; set; } = new List<Expense>();

    public async Task OnGetAsync()
    {
        Expenses = await _context.Expenses
            .Include(expense => expense.ConstructionProject)
            .OrderByDescending(expense => expense.ExpenseDate)
            .ToListAsync();
    }
}

