using System.Security.Claims;

namespace ConstructionManagementSystem.Models;

public static class BuildTaskFlowPermissions
{
    public static bool CanManageProjects(ClaimsPrincipal user) => IsInAnyRole(user, BuildTaskFlowRoleNames.ProjectEditors);

    public static bool CanManageClients(ClaimsPrincipal user) => IsInAnyRole(user, BuildTaskFlowRoleNames.ClientEditors);

    public static bool CanManageMaterials(ClaimsPrincipal user) => IsInAnyRole(user, BuildTaskFlowRoleNames.MaterialEditors);

    public static bool CanManageSubcontractors(ClaimsPrincipal user) => IsInAnyRole(user, BuildTaskFlowRoleNames.SubcontractorEditors);

    public static bool CanManageWorkers(ClaimsPrincipal user) => IsInAnyRole(user, BuildTaskFlowRoleNames.WorkerEditors);

    public static bool CanManageFinancialRecords(ClaimsPrincipal user) => IsInAnyRole(user, BuildTaskFlowRoleNames.FinancialEditors);

    public static bool CanManageTasks(ClaimsPrincipal user) => IsInAnyRole(user, BuildTaskFlowRoleNames.TaskEditors);

    public static bool CanManageTeam(ClaimsPrincipal user) => user.IsInRole(BuildTaskFlowRoleNames.Admin);

    public static bool CanManageInvoices(ClaimsPrincipal user) => IsInAnyRole(user, BuildTaskFlowRoleNames.AccountingEditors);

    public static bool CanUseSqlQueries(ClaimsPrincipal user) => IsInAnyRole(user, BuildTaskFlowRoleNames.SqlUsers);

    private static bool IsInAnyRole(ClaimsPrincipal user, string commaSeparatedRoles)
    {
        return commaSeparatedRoles
            .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Any(user.IsInRole);
    }
}
