using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructionManagementSystem.Models;

public class MaterialPurchase
{
    public int Id { get; set; }

    [Display(Name = "Proje")]
    public int ConstructionProjectId { get; set; }

    [Display(Name = "Proje")]
    public ConstructionProject? ConstructionProject { get; set; }

    [Display(Name = "Malzeme")]
    public int MaterialId { get; set; }

    [Display(Name = "Malzeme")]
    public Material? Material { get; set; }

    [Display(Name = "Tedarikçi")]
    public int SupplierId { get; set; }

    [Display(Name = "Tedarikçi")]
    public Supplier? Supplier { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Alım Tarihi")]
    public DateTime PurchaseDate { get; set; } = DateTime.Today;

    [Column(TypeName = "decimal(18,2)")]
    [Range(0.01, 999999999, ErrorMessage = "Miktar 0'dan büyük olmalıdır.")]
    [Display(Name = "Miktar")]
    public decimal Quantity { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    [Range(0.01, 999999999, ErrorMessage = "Birim fiyat 0'dan büyük olmalıdır.")]
    [Display(Name = "Birim Fiyat")]
    public decimal UnitPrice { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    [Display(Name = "Toplam Tutar")]
    public decimal TotalAmount { get; set; }

    [StringLength(500)]
    [Display(Name = "Açıklama")]
    public string Description { get; set; } = string.Empty;
}

