using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Pages.Clients;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Client> Clients { get; set; } = new List<Client>();

    public async Task OnGetAsync()
    {
        Clients = await _context.Clients
            .OrderBy(client => client.CompanyName)
            .ToListAsync();
    }
}

