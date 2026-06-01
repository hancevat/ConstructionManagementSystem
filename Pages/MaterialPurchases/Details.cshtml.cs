using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Pages.MaterialPurchases;

public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DetailsModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public MaterialPurchase MaterialPurchase { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var purchase = await _context.MaterialPurchases
            .Include(item => item.ConstructionProject)
            .Include(item => item.Material)
            .Include(item => item.Supplier)
            .FirstOrDefaultAsync(item => item.Id == id);

        if (purchase is null)
        {
            return NotFound();
        }

        MaterialPurchase = purchase;

        return Page();
    }
}

