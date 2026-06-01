using System.ComponentModel.DataAnnotations;

namespace ConstructionManagementSystem.Models;

public class BuildTaskFlowComment
{
    public int Id { get; set; }

    [Display(Name = "Görev")]
    [Required(ErrorMessage = "Görev seçimi zorunludur.")]
    public int BuildTaskFlowTaskId { get; set; }

    [Display(Name = "Ekip Üyesi")]
    [Required(ErrorMessage = "Ekip üyesi seçimi zorunludur.")]
    public int BuildTaskFlowTeamMemberId { get; set; }

    [Display(Name = "Yorum")]
    [Required(ErrorMessage = "Yorum metni zorunludur.")]
    [StringLength(1200)]
    public string Text { get; set; } = string.Empty;

    [Display(Name = "Yorum Tarihi")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public BuildTaskFlowTask? Task { get; set; }

    public BuildTaskFlowTeamMember? TeamMember { get; set; }
}
