using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Pages.Workers;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Worker> Workers { get; set; } = new List<Worker>();

    public async Task OnGetAsync()
    {
        Workers = await _context.Workers
            .OrderBy(worker => worker.FullName)
            .ToListAsync();
    }
}

