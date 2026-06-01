using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConstructionManagementSystem.Models;

public class ConstructionProject
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Proje adı zorunludur.")]
    [StringLength(120)]
    [Display(Name = "Proje Adı")]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "Müşteri")]
    public int ClientId { get; set; }

    [Display(Name = "Müşteri")]
    public Client? Client { get; set; }

    [Required(ErrorMessage = "Lokasyon zorunludur.")]
    [StringLength(160)]
    [Display(Name = "Lokasyon")]
    public string Location { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    [Display(Name = "Başlangıç Tarihi")]
    public DateTime StartDate { get; set; } = DateTime.Today;

    [DataType(DataType.Date)]
    [Display(Name = "Bitiş Tarihi")]
    public DateTime? EndDate { get; set; }

    [Required(ErrorMessage = "Durum zorunludur.")]
    [StringLength(40)]
    [Display(Name = "Durum")]
    public string Status { get; set; } = "Aktif";

    [Column(TypeName = "decimal(18,2)")]
    [Range(0, 999999999, ErrorMessage = "Sözleşme bedeli negatif olamaz.")]
    [Display(Name = "Sözleşme Bedeli")]
    public decimal ContractAmount { get; set; }

    [StringLength(500)]
    [Display(Name = "Açıklama")]
    public string Description { get; set; } = string.Empty;

    public ICollection<MaterialPurchase> MaterialPurchases { get; set; } = new List<MaterialPurchase>();

    public ICollection<WorkerPayment> WorkerPayments { get; set; } = new List<WorkerPayment>();

    public ICollection<ProjectIncome> ProjectIncomes { get; set; } = new List<ProjectIncome>();

    public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
}

