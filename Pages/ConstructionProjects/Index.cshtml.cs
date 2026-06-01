using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Pages.ConstructionProjects;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<ConstructionProject> ConstructionProjects { get; set; } = new List<ConstructionProject>();

    public async Task OnGetAsync()
    {
        ConstructionProjects = await _context.ConstructionProjects
            .Include(project => project.Client)
            .OrderByDescending(project => project.StartDate)
            .ToListAsync();
    }
}

