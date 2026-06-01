using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Pages.MaterialPurchases;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public MaterialPurchase MaterialPurchase { get; set; } = new();

    public SelectList ProjectOptions { get; set; } = null!;

    public SelectList MaterialOptions { get; set; } = null!;

    public SelectList SupplierOptions { get; set; } = null!;

    public async Task OnGetAsync()
    {
        await LoadOptionsAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var material = await _context.Materials.FindAsync(MaterialPurchase.MaterialId);

        if (!await _context.ConstructionProjects.AnyAsync(project => project.Id == MaterialPurchase.ConstructionProjectId))
        {
            ModelState.AddModelError("MaterialPurchase.ConstructionProjectId", "Geçerli bir proje seçin.");
        }

        if (material is null)
        {
            ModelState.AddModelError("MaterialPurchase.MaterialId", "Geçerli bir malzeme seçin.");
        }

        if (!await _context.Suppliers.AnyAsync(supplier => supplier.Id == MaterialPurchase.SupplierId))
        {
            ModelState.AddModelError("MaterialPurchase.SupplierId", "Geçerli bir tedarikçi seçin.");
        }

        if (!ModelState.IsValid)
        {
            await LoadOptionsAsync();
            return Page();
        }

        MaterialPurchase.TotalAmount = MaterialPurchase.Quantity * MaterialPurchase.UnitPrice;
        material!.StockQuantity += MaterialPurchase.Quantity;

        _context.MaterialPurchases.Add(MaterialPurchase);
        await _context.SaveChangesAsync();
        TempData["SuccessMessage"] = "Malzeme alımı kaydedildi ve stok miktarı güncellendi.";

        return RedirectToPage("./Index");
    }

    private async Task LoadOptionsAsync()
    {
        ProjectOptions = new SelectList(await _context.ConstructionProjects.OrderBy(project => project.Name).ToListAsync(), "Id", "Name", MaterialPurchase.ConstructionProjectId);
        MaterialOptions = new SelectList(await _context.Materials.OrderBy(material => material.Name).ToListAsync(), "Id", "Name", MaterialPurchase.MaterialId);
        SupplierOptions = new SelectList(await _context.Suppliers.OrderBy(supplier => supplier.CompanyName).ToListAsync(), "Id", "CompanyName", MaterialPurchase.SupplierId);
    }
}

