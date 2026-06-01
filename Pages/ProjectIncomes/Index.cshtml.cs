using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Pages.ProjectIncomes;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<ProjectIncome> ProjectIncomes { get; set; } = new List<ProjectIncome>();

    public async Task OnGetAsync()
    {
        ProjectIncomes = await _context.ProjectIncomes
            .Include(income => income.ConstructionProject)
            .OrderByDescending(income => income.IncomeDate)
            .ToListAsync();
    }
}

