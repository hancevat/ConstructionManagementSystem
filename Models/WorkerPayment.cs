using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructionManagementSystem.Models;

public class WorkerPayment
{
    public int Id { get; set; }

    [Display(Name = "İşçi")]
    public int WorkerId { get; set; }

    [Display(Name = "İşçi")]
    public Worker? Worker { get; set; }

    [Display(Name = "Proje")]
    public int ConstructionProjectId { get; set; }

    [Display(Name = "Proje")]
    public ConstructionProject? ConstructionProject { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Ödeme Tarihi")]
    public DateTime PaymentDate { get; set; } = DateTime.Today;

    [Range(1, 31, ErrorMessage = "Çalışılan gün sayısı 1 ile 31 arasında olmalıdır.")]
    [Display(Name = "Çalışılan Gün")]
    public int WorkDays { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    [Display(Name = "Tutar")]
    public decimal Amount { get; set; }

    [StringLength(500)]
    [Display(Name = "Açıklama")]
    public string Description { get; set; } = string.Empty;
}

