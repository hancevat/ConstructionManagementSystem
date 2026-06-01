using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Pages.Materials;

public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Material Material { get; set; } = null!;

    public SelectList MaterialTypeOptions { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var material = await _context.Materials.FindAsync(id);
        if (material is null)
        {
            return NotFound();
        }

        Material = material;

        await LoadMaterialTypesAsync();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        if (id != Material.Id)
        {
            return NotFound();
        }

        if (!await _context.MaterialTypes.AnyAsync(type => type.Id == Material.MaterialTypeId))
        {
            ModelState.AddModelError("Material.MaterialTypeId", "Geçerli bir malzeme türü seçin.");
        }

        if (!ModelState.IsValid)
        {
            await LoadMaterialTypesAsync();
            return Page();
        }

        _context.Attach(Material).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Malzeme kaydı güncellendi.";
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await _context.Materials.AnyAsync(material => material.Id == id))
            {
                return NotFound();
            }

            throw;
        }

        return RedirectToPage("./Index");
    }

    private async Task LoadMaterialTypesAsync()
    {
        var materialTypes = await _context.MaterialTypes.OrderBy(type => type.Name).ToListAsync();
        MaterialTypeOptions = new SelectList(materialTypes, "Id", "Name", Material.MaterialTypeId);
    }
}

