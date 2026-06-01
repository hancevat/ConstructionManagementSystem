using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Pages.WorkerPayments;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public WorkerPayment WorkerPayment { get; set; } = new();

    public SelectList WorkerOptions { get; set; } = null!;

    public SelectList ProjectOptions { get; set; } = null!;

    public async Task OnGetAsync()
    {
        await LoadOptionsAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var worker = await _context.Workers.FindAsync(WorkerPayment.WorkerId);

        if (worker is null)
        {
            ModelState.AddModelError("WorkerPayment.WorkerId", "Geçerli bir işçi seçin.");
        }

        if (!await _context.ConstructionProjects.AnyAsync(project => project.Id == WorkerPayment.ConstructionProjectId))
        {
            ModelState.AddModelError("WorkerPayment.ConstructionProjectId", "Geçerli bir proje seçin.");
        }

        if (!ModelState.IsValid)
        {
            await LoadOptionsAsync();
            return Page();
        }

        WorkerPayment.Amount = WorkerPayment.WorkDays * worker!.DailyWage;

        _context.WorkerPayments.Add(WorkerPayment);
        await _context.SaveChangesAsync();
        TempData["SuccessMessage"] = "İşçi ödemesi kaydedildi.";

        return RedirectToPage("./Index");
    }

    private async Task LoadOptionsAsync()
    {
        WorkerOptions = new SelectList(await _context.Workers.Where(worker => worker.IsActive).OrderBy(worker => worker.FullName).ToListAsync(), "Id", "FullName", WorkerPayment.WorkerId);
        ProjectOptions = new SelectList(await _context.ConstructionProjects.OrderBy(project => project.Name).ToListAsync(), "Id", "Name", WorkerPayment.ConstructionProjectId);
    }
}

