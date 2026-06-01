using System.ComponentModel.DataAnnotations;

namespace ConstructionManagementSystem.Models;

public class MaterialType
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Malzeme türü adı zorunludur.")]
    [StringLength(80)]
    [Display(Name = "Malzeme Türü")]
    public string Name { get; set; } = string.Empty;

    public ICollection<Material> Materials { get; set; } = new List<Material>();
}

