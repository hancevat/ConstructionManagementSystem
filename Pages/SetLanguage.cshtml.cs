using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ConstructionManagementSystem.Pages;

[AllowAnonymous]
public class SetLanguageModel : PageModel
{
    public IActionResult OnGet(string culture, string? returnUrl = null)
    {
        var uiCulture = string.Equals(culture, "en", StringComparison.OrdinalIgnoreCase) ||
            string.Equals(culture, "en-US", StringComparison.OrdinalIgnoreCase)
            ? "en-US"
            : "tr-TR";

        var requestCulture = new RequestCulture("tr-TR", uiCulture);

        Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(requestCulture),
            new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddYears(1),
                IsEssential = true,
                SameSite = SameSiteMode.Lax
            });

        if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
        {
            return LocalRedirect(returnUrl);
        }

        return RedirectToPage("/Index");
    }
}
