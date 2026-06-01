using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructionManagementSystem.Models;

public class Worker
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Ad soyad zorunludur.")]
    [StringLength(100)]
    [Display(Name = "Ad Soyad")]
    public string FullName { get; set; } = string.Empty;

    [StringLength(20)]
    [Display(Name = "Telefon")]
    public string Phone { get; set; } = string.Empty;

    [Required(ErrorMessage = "Görev zorunludur.")]
    [StringLength(80)]
    [Display(Name = "Görev")]
    public string JobTitle { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18,2)")]
    [Range(0, 999999999, ErrorMessage = "Günlük ücret negatif olamaz.")]
    [Display(Name = "Günlük Ücret")]
    public decimal DailyWage { get; set; }

    [Display(Name = "Aktif mi?")]
    public bool IsActive { get; set; } = true;

    public ICollection<WorkerPayment> WorkerPayments { get; set; } = new List<WorkerPayment>();
}

