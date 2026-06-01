using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Pages.ConstructionProjects;

public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public ConstructionProject ConstructionProject { get; set; } = null!;

    public SelectList ClientOptions { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var project = await _context.ConstructionProjects.FindAsync(id);
        if (project is null)
        {
            return NotFound();
        }

        ConstructionProject = project;
        await LoadClientsAsync();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        if (id != ConstructionProject.Id)
        {
            return NotFound();
        }

        if (!await _context.Clients.AnyAsync(client => client.Id == ConstructionProject.ClientId))
        {
            ModelState.AddModelError("ConstructionProject.ClientId", "Geçerli bir müşteri seçin.");
        }

        if (!ModelState.IsValid)
        {
            await LoadClientsAsync();
            return Page();
        }

        _context.Attach(ConstructionProject).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Proje kaydı güncellendi.";
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await _context.ConstructionProjects.AnyAsync(project => project.Id == id))
            {
                return NotFound();
            }

            throw;
        }

        return RedirectToPage("./Index");
    }

    private async Task LoadClientsAsync()
    {
        var clients = await _context.Clients.OrderBy(client => client.CompanyName).ToListAsync();
        ClientOptions = new SelectList(clients, "Id", "CompanyName", ConstructionProject.ClientId);
    }
}

