using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Pages.BuildTaskFlow.Invoices;

[Authorize(Roles = BuildTaskFlowRoleNames.AccountingEditors)]
public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public BuildTaskFlowInvoice Invoice { get; set; } = new();

    [BindProperty]
    public BuildTaskFlowInvoiceItem InvoiceItem { get; set; } = new() { Quantity = 1m };

    public SelectList ProjectOptions { get; set; } = null!;

    public string[] StatusOptions { get; } = ["Taslak", "Kesildi", "Ödendi", "İptal"];

    public async Task OnGetAsync()
    {
        Invoice.InvoiceNumber = $"PRF-{DateTime.Today:yyyyMMdd}-001";
        await LoadProjectsAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!await _context.BuildTaskFlowProjects.AnyAsync(project => project.Id == Invoice.BuildTaskFlowProjectId))
        {
            ModelState.AddModelError("Invoice.BuildTaskFlowProjectId", "Geçerli bir proje seçin.");
        }

        if (await _context.BuildTaskFlowInvoices.AnyAsync(item => item.InvoiceNumber == Invoice.InvoiceNumber))
        {
            ModelState.AddModelError("Invoice.InvoiceNumber", "Bu numara ile kayıtlı bir taslak var.");
        }

        if (!ModelState.IsValid)
        {
            await LoadProjectsAsync();
            return Page();
        }

        InvoiceItem.LineTotal = InvoiceItem.Quantity * InvoiceItem.UnitPrice;
        Invoice.SubTotal = InvoiceItem.LineTotal;
        Invoice.TaxAmount = Invoice.SubTotal * Invoice.TaxRate / 100m;
        Invoice.GrandTotal = Invoice.SubTotal + Invoice.TaxAmount;
        Invoice.Items.Add(InvoiceItem);

        _context.BuildTaskFlowInvoices.Add(Invoice);
        await _context.SaveChangesAsync();
        TempData["SuccessMessage"] = "Proforma/fatura taslağı oluşturuldu.";

        return RedirectToPage("Details", new { id = Invoice.Id });
    }

    private async Task LoadProjectsAsync()
    {
        ProjectOptions = new SelectList(await _context.BuildTaskFlowProjects.OrderBy(project => project.Name).ToListAsync(), "Id", "Name", Invoice.BuildTaskFlowProjectId);
    }
}
