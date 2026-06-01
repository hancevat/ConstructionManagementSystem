using System.ComponentModel.DataAnnotations;

namespace ConstructionManagementSystem.Models;

public class Subcontractor
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Firma adı zorunludur.")]
    [StringLength(120)]
    [Display(Name = "Firma Adı")]
    public string CompanyName { get; set; } = string.Empty;

    [Required(ErrorMessage = "İş türü zorunludur.")]
    [StringLength(80)]
    [Display(Name = "İş Türü")]
    public string WorkType { get; set; } = string.Empty;

    [StringLength(100)]
    [Display(Name = "Yetkili Kişi")]
    public string ContactName { get; set; } = string.Empty;

    [StringLength(20)]
    [Display(Name = "Telefon")]
    public string Phone { get; set; } = string.Empty;

    [StringLength(250)]
    [Display(Name = "Adres")]
    public string Address { get; set; } = string.Empty;
}

