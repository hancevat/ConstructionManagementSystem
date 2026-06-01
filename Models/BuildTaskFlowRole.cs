using System.ComponentModel.DataAnnotations;

namespace ConstructionManagementSystem.Models;

public class BuildTaskFlowRole
{
    public int Id { get; set; }

    [Display(Name = "Rol Adı")]
    [Required(ErrorMessage = "Rol adı zorunludur.")]
    [StringLength(80)]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "Açıklama")]
    [StringLength(300)]
    public string? Description { get; set; }

    public ICollection<BuildTaskFlowTeamMember> TeamMembers { get; set; } = new List<BuildTaskFlowTeamMember>();
}
