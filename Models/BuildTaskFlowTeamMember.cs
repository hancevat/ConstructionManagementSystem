using System.ComponentModel.DataAnnotations;

namespace ConstructionManagementSystem.Models;

public class BuildTaskFlowTeamMember
{
    public int Id { get; set; }

    [Display(Name = "Ad Soyad")]
    [Required(ErrorMessage = "Ad soyad zorunludur.")]
    [StringLength(120)]
    public string FullName { get; set; } = string.Empty;

    [Display(Name = "E-posta")]
    [Required(ErrorMessage = "E-posta zorunludur.")]
    [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi girin.")]
    [StringLength(160)]
    public string Email { get; set; } = string.Empty;

    [Display(Name = "Telefon")]
    [StringLength(30)]
    public string? Phone { get; set; }

    [Required]
    [StringLength(128)]
    public string PasswordHash { get; set; } = string.Empty;

    [Display(Name = "Rol")]
    [Required(ErrorMessage = "Rol seçimi zorunludur.")]
    public int BuildTaskFlowRoleId { get; set; }

    [Display(Name = "Aktif mi?")]
    public bool IsActive { get; set; } = true;

    [Display(Name = "Kayıt Tarihi")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public BuildTaskFlowRole? Role { get; set; }

    public ICollection<BuildTaskFlowProject> OwnedProjects { get; set; } = new List<BuildTaskFlowProject>();

    public ICollection<BuildTaskFlowTaskAssignment> TaskAssignments { get; set; } = new List<BuildTaskFlowTaskAssignment>();

    public ICollection<BuildTaskFlowComment> Comments { get; set; } = new List<BuildTaskFlowComment>();
}
