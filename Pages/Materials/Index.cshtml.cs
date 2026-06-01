using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Pages.Materials;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Material> Materials { get; set; } = new List<Material>();

    public async Task OnGetAsync()
    {
        Materials = await _context.Materials
            .Include(material => material.MaterialType)
            .OrderBy(material => material.Name)
            .ToListAsync();
    }
}

