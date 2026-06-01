using System.ComponentModel.DataAnnotations;

namespace ConstructionManagementSystem.Models;

public class BuildTaskFlowInvoice
{
    public int Id { get; set; }

    [Display(Name = "Fatura/Proforma No")]
    [Required(ErrorMessage = "Fatura/proforma numarası zorunludur.")]
    [StringLength(40)]
    public string InvoiceNumber { get; set; } = string.Empty;

    [Display(Name = "Proje")]
    [Required(ErrorMessage = "Proje seçimi zorunludur.")]
    public int BuildTaskFlowProjectId { get; set; }

    [Display(Name = "Müşteri / Firma")]
    [Required(ErrorMessage = "Müşteri bilgisi zorunludur.")]
    [StringLength(160)]
    public string CustomerTitle { get; set; } = string.Empty;

    [Display(Name = "Fatura Tarihi")]
    [DataType(DataType.Date)]
    public DateTime InvoiceDate { get; set; } = DateTime.Today;

    [Display(Name = "Vade Tarihi")]
    [DataType(DataType.Date)]
    public DateTime? DueDate { get; set; }

    [Display(Name = "Durum")]
    [Required(ErrorMessage = "Durum zorunludur.")]
    [StringLength(40)]
    public string Status { get; set; } = "Taslak";

    [Display(Name = "Ara Toplam")]
    public decimal SubTotal { get; set; }

    [Display(Name = "KDV Oranı (%)")]
    public decimal TaxRate { get; set; } = 20m;

    [Display(Name = "KDV Tutarı")]
    public decimal TaxAmount { get; set; }

    [Display(Name = "Genel Toplam")]
    public decimal GrandTotal { get; set; }

    [Display(Name = "Not")]
    [StringLength(1000)]
    public string? Notes { get; set; }

    public BuildTaskFlowProject? Project { get; set; }

    public ICollection<BuildTaskFlowInvoiceItem> Items { get; set; } = new List<BuildTaskFlowInvoiceItem>();
}
