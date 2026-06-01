using System.ComponentModel.DataAnnotations;

namespace ConstructionManagementSystem.Models;

public class BuildTaskFlowProject
{
    public int Id { get; set; }

    [Display(Name = "Proje Adı")]
    [Required(ErrorMessage = "Proje adı zorunludur.")]
    [StringLength(150)]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "Açıklama")]
    [StringLength(1000)]
    public string? Description { get; set; }

    [Display(Name = "Başlangıç Tarihi")]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; } = DateTime.Today;

    [Display(Name = "Teslim Tarihi")]
    [DataType(DataType.Date)]
    public DateTime? EndDate { get; set; }

    [Display(Name = "Durum")]
    [Required(ErrorMessage = "Durum zorunludur.")]
    [StringLength(40)]
    public string Status { get; set; } = "Devam Ediyor";

    [Display(Name = "Proje Sorumlusu")]
    public int? OwnerTeamMemberId { get; set; }

    public BuildTaskFlowTeamMember? OwnerTeamMember { get; set; }

    public ICollection<BuildTaskFlowTask> Tasks { get; set; } = new List<BuildTaskFlowTask>();

    public ICollection<BuildTaskFlowInvoice> Invoices { get; set; } = new List<BuildTaskFlowInvoice>();
}
