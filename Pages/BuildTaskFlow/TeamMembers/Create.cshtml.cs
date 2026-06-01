using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using ConstructionManagementSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ConstructionManagementSystem.Pages.BuildTaskFlow.TeamMembers;

[Authorize(Roles = BuildTaskFlowRoleNames.Admin)]
public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public TeamMemberInput Input { get; set; } = new();

    public SelectList RoleOptions { get; set; } = null!;

    public async Task OnGetAsync()
    {
        await LoadRolesAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (await _context.BuildTaskFlowTeamMembers.AnyAsync(member => member.Email == Input.Email))
        {
            ModelState.AddModelError("Input.Email", "Bu e-posta ile kayıtlı bir kullanıcı var.");
        }

        if (!await _context.BuildTaskFlowRoles.AnyAsync(role => role.Id == Input.BuildTaskFlowRoleId))
        {
            ModelState.AddModelError("Input.BuildTaskFlowRoleId", "Geçerli bir rol seçin.");
        }

        if (!ModelState.IsValid)
        {
            await LoadRolesAsync();
            return Page();
        }

        _context.BuildTaskFlowTeamMembers.Add(new BuildTaskFlowTeamMember
        {
            FullName = Input.FullName,
            Email = Input.Email.Trim().ToLowerInvariant(),
            Phone = Input.Phone,
            BuildTaskFlowRoleId = Input.BuildTaskFlowRoleId,
            PasswordHash = BuildTaskFlowPasswordHasher.HashPassword(Input.Password),
            IsActive = Input.IsActive,
            CreatedAt = DateTime.Now
        });

        await _context.SaveChangesAsync();
        TempData["SuccessMessage"] = "BuildTaskFlow kullanıcısı oluşturuldu.";

        return RedirectToPage("Index");
    }

    private async Task LoadRolesAsync()
    {
        RoleOptions = new SelectList(await _context.BuildTaskFlowRoles.OrderBy(role => role.Name).ToListAsync(), "Id", "Name", Input.BuildTaskFlowRoleId);
    }

    public class TeamMemberInput
    {
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

        [Display(Name = "Rol")]
        [Required(ErrorMessage = "Rol seçimi zorunludur.")]
        public int BuildTaskFlowRoleId { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre zorunludur.")]
        [StringLength(80, MinimumLength = 6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Aktif mi?")]
        public bool IsActive { get; set; } = true;
    }
}
