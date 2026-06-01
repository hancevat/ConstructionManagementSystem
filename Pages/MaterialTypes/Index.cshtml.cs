using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Pages.MaterialTypes;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<MaterialType> MaterialTypes { get; set; } = new List<MaterialType>();

    public async Task OnGetAsync()
    {
        MaterialTypes = await _context.MaterialTypes
            .OrderBy(type => type.Name)
            .ToListAsync();
    }
}

