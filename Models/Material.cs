using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructionManagementSystem.Models;

public class Material
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Malzeme adı zorunludur.")]
    [StringLength(120)]
    [Display(Name = "Malzeme Adı")]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "Malzeme Türü")]
    public int MaterialTypeId { get; set; }

    [Display(Name = "Malzeme Türü")]
    public MaterialType? MaterialType { get; set; }

    [Required(ErrorMessage = "Birim zorunludur.")]
    [StringLength(30)]
    [Display(Name = "Birim")]
    public string Unit { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18,2)")]
    [Range(0, 999999999, ErrorMessage = "Birim fiyat negatif olamaz.")]
    [Display(Name = "Birim Fiyat")]
    public decimal UnitPrice { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    [Range(0, 999999999, ErrorMessage = "Stok miktarı negatif olamaz.")]
    [Display(Name = "Stok Miktarı")]
    public decimal StockQuantity { get; set; }

    [StringLength(500)]
    [Display(Name = "Açıklama")]
    public string Description { get; set; } = string.Empty;

    public ICollection<MaterialPurchase> MaterialPurchases { get; set; } = new List<MaterialPurchase>();
}

