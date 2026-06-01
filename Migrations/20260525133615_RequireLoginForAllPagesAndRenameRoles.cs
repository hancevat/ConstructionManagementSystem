using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConstructionManagementSystem.Migrations
{
    public partial class RequireLoginForAllPagesAndRenameRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BuildTaskFlowRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Şantiye projelerini, işçileri ve saha görevlerini takip eder.", "Şantiye Şefi" });

            migrationBuilder.UpdateData(
                table: "BuildTaskFlowRoles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Malzemeleri, tedarikçileri, stokları ve malzeme alımlarını yönetir.", "Depo / Malzeme Sorumlusu" });

            migrationBuilder.UpdateData(
                table: "BuildTaskFlowTeamMembers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "FullName" },
                values: new object[] { "santiyesefi@buildtaskflow.local", "Mert Şantiye Şefi" });

            migrationBuilder.UpdateData(
                table: "BuildTaskFlowTeamMembers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "FullName" },
                values: new object[] { "depo@buildtaskflow.local", "Selin Depo Sorumlusu" });
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BuildTaskFlowRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Şantiye projelerini, işçileri ve saha görevlerini takip eder.", "Şantiye Şefi" });

            migrationBuilder.UpdateData(
                table: "BuildTaskFlowRoles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Malzemeleri, tedarikçileri, stokları ve malzeme alımlarını yönetir.", "Depo / Malzeme Sorumlusu" });

            migrationBuilder.UpdateData(
                table: "BuildTaskFlowTeamMembers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "FullName" },
                values: new object[] { "santiyesefi@buildtaskflow.local", "Mert Şantiye Şefi" });

            migrationBuilder.UpdateData(
                table: "BuildTaskFlowTeamMembers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "FullName" },
                values: new object[] { "depo@buildtaskflow.local", "Selin Depo Sorumlusu" });
        }
    }
}
