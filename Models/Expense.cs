using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructionManagementSystem.Models;

public class Expense
{
    public int Id { get; set; }

    [Display(Name = "Proje")]
    public int ConstructionProjectId { get; set; }

    [Display(Name = "Proje")]
    public ConstructionProject? ConstructionProject { get; set; }

    [Required(ErrorMessage = "Gider başlığı zorunludur.")]
    [StringLength(120)]
    [Display(Name = "Başlık")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Kategori zorunludur.")]
    [StringLength(40)]
    [Display(Name = "Kategori")]
    public string Category { get; set; } = "Diğer";

    [Column(TypeName = "decimal(18,2)")]
    [Range(0.01, 999999999, ErrorMessage = "Gider tutarı 0'dan büyük olmalıdır.")]
    [Display(Name = "Tutar")]
    public decimal Amount { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Gider Tarihi")]
    public DateTime ExpenseDate { get; set; } = DateTime.Today;

    [StringLength(500)]
    [Display(Name = "Açıklama")]
    public string Description { get; set; } = string.Empty;
}

