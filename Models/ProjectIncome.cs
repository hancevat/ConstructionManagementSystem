using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructionManagementSystem.Models;

public class ProjectIncome
{
    public int Id { get; set; }

    [Display(Name = "Proje")]
    public int ConstructionProjectId { get; set; }

    [Display(Name = "Proje")]
    public ConstructionProject? ConstructionProject { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Gelir Tarihi")]
    public DateTime IncomeDate { get; set; } = DateTime.Today;

    [Column(TypeName = "decimal(18,2)")]
    [Range(0.01, 999999999, ErrorMessage = "Gelir tutarı 0'dan büyük olmalıdır.")]
    [Display(Name = "Tutar")]
    public decimal Amount { get; set; }

    [StringLength(500)]
    [Display(Name = "Açıklama")]
    public string Description { get; set; } = string.Empty;
}

