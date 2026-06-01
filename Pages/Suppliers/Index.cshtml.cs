using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Pages.Suppliers;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Supplier> Suppliers { get; set; } = new List<Supplier>();

    public async Task OnGetAsync()
    {
        Suppliers = await _context.Suppliers
            .OrderBy(supplier => supplier.CompanyName)
            .ToListAsync();
    }
}

