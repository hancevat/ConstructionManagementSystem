using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConstructionManagementSystem.Migrations
{
    public partial class AddBuildTaskFlowViewerUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BuildTaskFlowTeamMembers",
                columns: new[] { "Id", "BuildTaskFlowRoleId", "CreatedAt", "Email", "FullName", "IsActive", "PasswordHash", "Phone" },
                values: new object[] { 6, 6, new DateTime(2026, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "goruntuleyici@buildtaskflow.local", "Can Görüntüleyici", true, "8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92", "0500 100 00 06" });
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BuildTaskFlowTeamMembers",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
