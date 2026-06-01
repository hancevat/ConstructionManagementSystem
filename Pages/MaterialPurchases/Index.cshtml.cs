using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Pages.MaterialPurchases;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<MaterialPurchase> MaterialPurchases { get; set; } = new List<MaterialPurchase>();

    public async Task OnGetAsync()
    {
        MaterialPurchases = await _context.MaterialPurchases
            .Include(purchase => purchase.ConstructionProject)
            .Include(purchase => purchase.Material)
            .Include(purchase => purchase.Supplier)
            .OrderByDescending(purchase => purchase.PurchaseDate)
            .ToListAsync();
    }
}

