using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Pages.ConstructionProjects;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public ConstructionProject ConstructionProject { get; set; } = new();

    public SelectList ClientOptions { get; set; } = null!;

    public async Task OnGetAsync()
    {
        await LoadClientsAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!await _context.Clients.AnyAsync(client => client.Id == ConstructionProject.ClientId))
        {
            ModelState.AddModelError("ConstructionProject.ClientId", "Geçerli bir müşteri seçin.");
        }

        if (!ModelState.IsValid)
        {
            await LoadClientsAsync();
            return Page();
        }

        _context.ConstructionProjects.Add(ConstructionProject);
        await _context.SaveChangesAsync();
        TempData["SuccessMessage"] = "Proje kaydı oluşturuldu.";

        return RedirectToPage("./Index");
    }

    private async Task LoadClientsAsync()
    {
        var clients = await _context.Clients.OrderBy(client => client.CompanyName).ToListAsync();
        ClientOptions = new SelectList(clients, "Id", "CompanyName", ConstructionProject.ClientId);
    }
}

