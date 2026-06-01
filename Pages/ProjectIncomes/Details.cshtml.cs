using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Pages.ProjectIncomes;

public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DetailsModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public ProjectIncome ProjectIncome { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var income = await _context.ProjectIncomes
            .Include(item => item.ConstructionProject)
            .FirstOrDefaultAsync(item => item.Id == id);

        if (income is null)
        {
            return NotFound();
        }

        ProjectIncome = income;

        return Page();
    }
}

