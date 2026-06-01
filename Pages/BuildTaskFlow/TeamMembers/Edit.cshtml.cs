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
public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public EditModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public TeamMemberInput Input { get; set; } = new();

    public SelectList RoleOptions { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var member = await _context.BuildTaskFlowTeamMembers.FindAsync(id);
        if (member is null)
        {
            return NotFound();
        }

        Input = new TeamMemberInput
        {
            Id = member.Id,
            FullName = member.FullName,
            Email = member.Email,
            Phone = member.Phone,
            BuildTaskFlowRoleId = member.BuildTaskFlowRoleId,
            IsActive = member.IsActive
        };

        await LoadRolesAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (await _context.BuildTaskFlowTeamMembers.AnyAsync(member => member.Email == Input.Email && member.Id != Input.Id))
        {
            ModelState.AddModelError("Input.Email", "Bu e-posta ile kayıtlı başka bir kullanıcı var.");
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

        var memberToUpdate = await _context.BuildTaskFlowTeamMembers.FindAsync(Input.Id);
        if (memberToUpdate is null)
        {
            return NotFound();
        }

        memberToUpdate.FullName = Input.FullName;
        memberToUpdate.Email = Input.Email.Trim().ToLowerInvariant();
        memberToUpdate.Phone = Input.Phone;
        memberToUpdate.BuildTaskFlowRoleId = Input.BuildTaskFlowRoleId;
        memberToUpdate.IsActive = Input.IsActive;

        if (!string.IsNullOrWhiteSpace(Input.NewPassword))
        {
            memberToUpdate.PasswordHash = BuildTaskFlowPasswordHasher.HashPassword(Input.NewPassword);
        }

        await _context.SaveChangesAsync();
        TempData["SuccessMessage"] = "BuildTaskFlow kullanıcısı güncellendi.";

        return RedirectToPage("Index");
    }

    private async Task LoadRolesAsync()
    {
        RoleOptions = new SelectList(await _context.BuildTaskFlowRoles.OrderBy(role => role.Name).ToListAsync(), "Id", "Name", Input.BuildTaskFlowRoleId);
    }

    public class TeamMemberInput
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

        [Display(Name = "Rol")]
        [Required(ErrorMessage = "Rol seçimi zorunludur.")]
        public int BuildTaskFlowRoleId { get; set; }

        [Display(Name = "Yeni Şifre")]
        [StringLength(80, MinimumLength = 6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        [DataType(DataType.Password)]
        public string? NewPassword { get; set; }

        [Display(Name = "Aktif mi?")]
        public bool IsActive { get; set; } = true;
    }
}
