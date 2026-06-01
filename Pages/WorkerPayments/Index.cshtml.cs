using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Pages.WorkerPayments;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<WorkerPayment> WorkerPayments { get; set; } = new List<WorkerPayment>();

    public async Task OnGetAsync()
    {
        WorkerPayments = await _context.WorkerPayments
            .Include(payment => payment.Worker)
            .Include(payment => payment.ConstructionProject)
            .OrderByDescending(payment => payment.PaymentDate)
            .ToListAsync();
    }
}

