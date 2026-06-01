using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Pages.Subcontractors;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Subcontractor> Subcontractors { get; set; } = new List<Subcontractor>();

    public async Task OnGetAsync()
    {
        Subcontractors = await _context.Subcontractors
            .OrderBy(subcontractor => subcontractor.CompanyName)
            .ToListAsync();
    }
}

