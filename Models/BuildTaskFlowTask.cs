using System.ComponentModel.DataAnnotations;

namespace ConstructionManagementSystem.Models;

public class BuildTaskFlowTask
{
    public int Id { get; set; }

    [Display(Name = "Proje")]
    [Required(ErrorMessage = "Proje seçimi zorunludur.")]
    public int BuildTaskFlowProjectId { get; set; }

    [Display(Name = "Durum")]
    [Required(ErrorMessage = "Durum seçimi zorunludur.")]
    public int BuildTaskFlowTaskStatusId { get; set; }

    [Display(Name = "Görev Başlığı")]
    [Required(ErrorMessage = "Görev başlığı zorunludur.")]
    [StringLength(180)]
    public string Title { get; set; } = string.Empty;

    [Display(Name = "Açıklama")]
    [StringLength(1500)]
    public string? Description { get; set; }

    [Display(Name = "Öncelik")]
    [Required(ErrorMessage = "Öncelik zorunludur.")]
    [StringLength(30)]
    public string Priority { get; set; } = "Orta";

    [Display(Name = "Teslim Tarihi")]
    [DataType(DataType.Date)]
    public DateTime? DueDate { get; set; }

    [Display(Name = "Oluşturulma Tarihi")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Display(Name = "Tamamlanma Tarihi")]
    public DateTime? CompletedAt { get; set; }

    public BuildTaskFlowProject? Project { get; set; }

    public BuildTaskFlowTaskStatus? Status { get; set; }

    public ICollection<BuildTaskFlowTaskAssignment> Assignments { get; set; } = new List<BuildTaskFlowTaskAssignment>();

    public ICollection<BuildTaskFlowComment> Comments { get; set; } = new List<BuildTaskFlowComment>();
}
