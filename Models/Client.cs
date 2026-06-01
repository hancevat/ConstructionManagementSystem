using System.ComponentModel.DataAnnotations;

namespace ConstructionManagementSystem.Models;

public class Client
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Ad soyad zorunludur.")]
    [StringLength(100)]
    [Display(Name = "Ad Soyad")]
    public string FullName { get; set; } = string.Empty;

    [StringLength(120)]
    [Display(Name = "Firma Adı")]
    public string CompanyName { get; set; } = string.Empty;

    [StringLength(20)]
    [Display(Name = "Telefon")]
    public string Phone { get; set; } = string.Empty;

    [StringLength(250)]
    [Display(Name = "Adres")]
    public string Address { get; set; } = string.Empty;

    public ICollection<ConstructionProject> ConstructionProjects { get; set; } = new List<ConstructionProject>();
}

