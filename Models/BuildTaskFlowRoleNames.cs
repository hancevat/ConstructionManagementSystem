namespace ConstructionManagementSystem.Models;

public static class BuildTaskFlowRoleNames
{
    public const string Admin = "Yönetici";
    public const string ProjectManager = "Proje Sorumlusu";
    public const string SiteChief = "Şantiye Şefi";
    public const string MaterialManager = "Depo / Malzeme Sorumlusu";
    public const string Accounting = "Muhasebe";
    public const string Viewer = "Görüntüleyici";

    public const string AdminOrProjectManager = Admin + "," + ProjectManager;
    public const string TaskEditors = Admin + "," + ProjectManager + "," + SiteChief + "," + MaterialManager;
    public const string AccountingEditors = Admin + "," + Accounting;
    public const string ProjectEditors = Admin + "," + ProjectManager + "," + SiteChief;
    public const string ClientEditors = Admin + "," + ProjectManager;
    public const string MaterialEditors = Admin + "," + MaterialManager;
    public const string SubcontractorEditors = Admin + "," + ProjectManager + "," + SiteChief;
    public const string WorkerEditors = Admin + "," + SiteChief;
    public const string FinancialEditors = Admin + "," + Accounting;
    public const string SqlUsers = Admin + "," + ProjectManager;
}
