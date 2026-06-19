using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConstructionManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddBuildTaskFlowGanttProgress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProgressPercentage",
                table: "BuildTaskFlowTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "BuildTaskFlowTasks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "BuildTaskFlowTasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ProgressPercentage", "StartDate" },
                values: new object[] { 100, new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BuildTaskFlowTasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ProgressPercentage", "StartDate" },
                values: new object[] { 100, new DateTime(2026, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BuildTaskFlowTasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ProgressPercentage", "StartDate" },
                values: new object[] { 65, new DateTime(2026, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BuildTaskFlowTasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ProgressPercentage", "StartDate" },
                values: new object[] { 85, new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BuildTaskFlowTasks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ProgressPercentage", "StartDate" },
                values: new object[] { 35, new DateTime(2026, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BuildTaskFlowTasks",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ProgressPercentage", "StartDate" },
                values: new object[] { 25, new DateTime(2026, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProgressPercentage",
                table: "BuildTaskFlowTasks");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "BuildTaskFlowTasks");
        }
    }
}
