using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
var defaultCulture = new CultureInfo("tr-TR");
var supportedCultures = new[] { defaultCulture };
var supportedUICultures = new[] { defaultCulture, new CultureInfo("en-US") };
CultureInfo.DefaultThreadCurrentCulture = defaultCulture;
CultureInfo.DefaultThreadCurrentUICulture = defaultCulture;

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "ConstructionManagementAuth";
        options.LoginPath = "/BuildTaskFlow/Login";
        options.AccessDeniedPath = "/BuildTaskFlow/AccessDenied";
        options.ExpireTimeSpan = TimeSpan.FromHours(8);
        options.SlidingExpiration = true;
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(BuildTaskFlowRoleNames.ProjectEditors, policy => policy.RequireRole(SplitRoles(BuildTaskFlowRoleNames.ProjectEditors)));
    options.AddPolicy(BuildTaskFlowRoleNames.ClientEditors, policy => policy.RequireRole(SplitRoles(BuildTaskFlowRoleNames.ClientEditors)));
    options.AddPolicy(BuildTaskFlowRoleNames.MaterialEditors, policy => policy.RequireRole(SplitRoles(BuildTaskFlowRoleNames.MaterialEditors)));
    options.AddPolicy(BuildTaskFlowRoleNames.SubcontractorEditors, policy => policy.RequireRole(SplitRoles(BuildTaskFlowRoleNames.SubcontractorEditors)));
    options.AddPolicy(BuildTaskFlowRoleNames.WorkerEditors, policy => policy.RequireRole(SplitRoles(BuildTaskFlowRoleNames.WorkerEditors)));
    options.AddPolicy(BuildTaskFlowRoleNames.FinancialEditors, policy => policy.RequireRole(SplitRoles(BuildTaskFlowRoleNames.FinancialEditors)));
    options.AddPolicy(BuildTaskFlowRoleNames.SqlUsers, policy => policy.RequireRole(SplitRoles(BuildTaskFlowRoleNames.SqlUsers)));
});
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/");
    options.Conventions.AllowAnonymousToPage("/BuildTaskFlow/Login");
    options.Conventions.AllowAnonymousToPage("/BuildTaskFlow/AccessDenied");
    options.Conventions.AllowAnonymousToPage("/SetLanguage");
    options.Conventions.AllowAnonymousToPage("/Error");

    options.Conventions.AuthorizePage("/ConstructionProjects/Create", BuildTaskFlowRoleNames.ProjectEditors);
    options.Conventions.AuthorizePage("/ConstructionProjects/Edit", BuildTaskFlowRoleNames.ProjectEditors);
    options.Conventions.AuthorizePage("/ConstructionProjects/Delete", BuildTaskFlowRoleNames.ProjectEditors);
    options.Conventions.AuthorizePage("/Clients/Create", BuildTaskFlowRoleNames.ClientEditors);
    options.Conventions.AuthorizePage("/Clients/Edit", BuildTaskFlowRoleNames.ClientEditors);
    options.Conventions.AuthorizePage("/Clients/Delete", BuildTaskFlowRoleNames.ClientEditors);
    options.Conventions.AuthorizePage("/Materials/Create", BuildTaskFlowRoleNames.MaterialEditors);
    options.Conventions.AuthorizePage("/Materials/Edit", BuildTaskFlowRoleNames.MaterialEditors);
    options.Conventions.AuthorizePage("/Materials/Delete", BuildTaskFlowRoleNames.MaterialEditors);
    options.Conventions.AuthorizePage("/MaterialTypes/Create", BuildTaskFlowRoleNames.MaterialEditors);
    options.Conventions.AuthorizePage("/MaterialTypes/Edit", BuildTaskFlowRoleNames.MaterialEditors);
    options.Conventions.AuthorizePage("/MaterialTypes/Delete", BuildTaskFlowRoleNames.MaterialEditors);
    options.Conventions.AuthorizePage("/Suppliers/Create", BuildTaskFlowRoleNames.MaterialEditors);
    options.Conventions.AuthorizePage("/Suppliers/Edit", BuildTaskFlowRoleNames.MaterialEditors);
    options.Conventions.AuthorizePage("/Suppliers/Delete", BuildTaskFlowRoleNames.MaterialEditors);
    options.Conventions.AuthorizePage("/MaterialPurchases/Create", BuildTaskFlowRoleNames.MaterialEditors);
    options.Conventions.AuthorizePage("/Subcontractors/Create", BuildTaskFlowRoleNames.SubcontractorEditors);
    options.Conventions.AuthorizePage("/Subcontractors/Edit", BuildTaskFlowRoleNames.SubcontractorEditors);
    options.Conventions.AuthorizePage("/Subcontractors/Delete", BuildTaskFlowRoleNames.SubcontractorEditors);
    options.Conventions.AuthorizePage("/Workers/Create", BuildTaskFlowRoleNames.WorkerEditors);
    options.Conventions.AuthorizePage("/Workers/Edit", BuildTaskFlowRoleNames.WorkerEditors);
    options.Conventions.AuthorizePage("/Workers/Delete", BuildTaskFlowRoleNames.WorkerEditors);
    options.Conventions.AuthorizePage("/WorkerPayments/Create", BuildTaskFlowRoleNames.FinancialEditors);
    options.Conventions.AuthorizePage("/ProjectIncomes/Create", BuildTaskFlowRoleNames.FinancialEditors);
    options.Conventions.AuthorizePage("/Expenses/Create", BuildTaskFlowRoleNames.FinancialEditors);
    options.Conventions.AuthorizePage("/Expenses/Edit", BuildTaskFlowRoleNames.FinancialEditors);
    options.Conventions.AuthorizePage("/Expenses/Delete", BuildTaskFlowRoleNames.FinancialEditors);
    options.Conventions.AuthorizePage("/SqlQueries/Index", BuildTaskFlowRoleNames.SqlUsers);
});
builder.Services.AddDataProtection()
    .SetApplicationName("ConstructionManagementSystem")
    .PersistKeysToFileSystem(new DirectoryInfo(Path.Combine(builder.Environment.ContentRootPath, "App_Data", "DataProtectionKeys")));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("tr-TR", "tr-TR"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedUICultures
});

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();

static string[] SplitRoles(string roles)
{
    return roles.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
}

