using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Pages.BuildTaskFlow.Invoices;

public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DetailsModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public BuildTaskFlowInvoice Invoice { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var invoice = await _context.BuildTaskFlowInvoices
            .Include(item => item.Project)
            .Include(item => item.Items)
            .FirstOrDefaultAsync(item => item.Id == id);

        if (invoice is null)
        {
            return NotFound();
        }

        Invoice = invoice;
        return Page();
    }
}
