using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Pages.BuildTaskFlow.Invoices;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<BuildTaskFlowInvoice> Invoices { get; set; } = new List<BuildTaskFlowInvoice>();

    public async Task OnGetAsync()
    {
        Invoices = await _context.BuildTaskFlowInvoices
            .Include(invoice => invoice.Project)
            .OrderByDescending(invoice => invoice.InvoiceDate)
            .ToListAsync();
    }
}
