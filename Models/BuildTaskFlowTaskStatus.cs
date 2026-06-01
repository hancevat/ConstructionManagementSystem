using System.ComponentModel.DataAnnotations;

namespace ConstructionManagementSystem.Models;

public class BuildTaskFlowTaskStatus
{
    public int Id { get; set; }

    [Display(Name = "Durum Adı")]
    [Required(ErrorMessage = "Durum adı zorunludur.")]
    [StringLength(80)]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "Sıra")]
    public int SortOrder { get; set; }

    public ICollection<BuildTaskFlowTask> Tasks { get; set; } = new List<BuildTaskFlowTask>();
}
