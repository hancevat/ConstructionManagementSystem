using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Pages.Materials;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Material Material { get; set; } = new();

    public SelectList MaterialTypeOptions { get; set; } = null!;

    public async Task OnGetAsync()
    {

        await LoadMaterialTypesAsync();

    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!await _context.MaterialTypes.AnyAsync(type => type.Id == Material.MaterialTypeId))
        {
            ModelState.AddModelError("Material.MaterialTypeId", "Geçerli bir malzeme türü seçin.");
        }

        if (!ModelState.IsValid)
        {
            await LoadMaterialTypesAsync();
            return Page();
        }

        _context.Materials.Add(Material);
        await _context.SaveChangesAsync();
        TempData["SuccessMessage"] = "Malzeme kaydı oluşturuldu.";

        return RedirectToPage("./Index");
    }

    private async Task LoadMaterialTypesAsync()
    {
        var materialTypes = await _context.MaterialTypes.OrderBy(type => type.Name).ToListAsync();
        MaterialTypeOptions = new SelectList(materialTypes, "Id", "Name", Material.MaterialTypeId);
    }
}

