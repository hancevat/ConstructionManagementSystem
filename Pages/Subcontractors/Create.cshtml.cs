using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ConstructionManagementSystem.Pages.Subcontractors;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Subcontractor Subcontractor { get; set; } = new();

    public IActionResult OnGet()
    {
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Subcontractors.Add(Subcontractor);
        await _context.SaveChangesAsync();
        TempData["SuccessMessage"] = "Taşeron kaydı oluşturuldu.";

        return RedirectToPage("./Index");
    }
}

