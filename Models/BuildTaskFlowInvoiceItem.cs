using System.ComponentModel.DataAnnotations;

namespace ConstructionManagementSystem.Models;

public class BuildTaskFlowInvoiceItem
{
    public int Id { get; set; }

    [Display(Name = "Fatura/Proforma")]
    [Required(ErrorMessage = "Fatura/proforma seçimi zorunludur.")]
    public int BuildTaskFlowInvoiceId { get; set; }

    [Display(Name = "Kalem Açıklaması")]
    [Required(ErrorMessage = "Kalem açıklaması zorunludur.")]
    [StringLength(300)]
    public string Description { get; set; } = string.Empty;

    [Display(Name = "Miktar")]
    public decimal Quantity { get; set; }

    [Display(Name = "Birim Fiyat")]
    public decimal UnitPrice { get; set; }

    [Display(Name = "Tutar")]
    public decimal LineTotal { get; set; }

    public BuildTaskFlowInvoice? Invoice { get; set; }
}
