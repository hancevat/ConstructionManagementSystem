using System.ComponentModel.DataAnnotations;

namespace ConstructionManagementSystem.Models;

public class BuildTaskFlowTaskAssignment
{
    public int Id { get; set; }

    [Display(Name = "Görev")]
    [Required(ErrorMessage = "Görev seçimi zorunludur.")]
    public int BuildTaskFlowTaskId { get; set; }

    [Display(Name = "Ekip Üyesi")]
    [Required(ErrorMessage = "Ekip üyesi seçimi zorunludur.")]
    public int BuildTaskFlowTeamMemberId { get; set; }

    [Display(Name = "Atanma Tarihi")]
    public DateTime AssignedAt { get; set; } = DateTime.Now;

    public BuildTaskFlowTask? Task { get; set; }

    public BuildTaskFlowTeamMember? TeamMember { get; set; }
}
