using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Pages.WorkerPayments;

public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DetailsModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public WorkerPayment WorkerPayment { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var payment = await _context.WorkerPayments
            .Include(item => item.Worker)
            .Include(item => item.ConstructionProject)
            .FirstOrDefaultAsync(item => item.Id == id);

        if (payment is null)
        {
            return NotFound();
        }

        WorkerPayment = payment;

        return Page();
    }
}

