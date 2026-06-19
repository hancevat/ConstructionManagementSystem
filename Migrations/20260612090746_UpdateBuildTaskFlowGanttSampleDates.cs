using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConstructionManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBuildTaskFlowGanttSampleDates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BuildTaskFlowProjects",
                keyColumn: "Id",
                keyValue: 1,
                column: "EndDate",
                value: new DateTime(2026, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "BuildTaskFlowProjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "Status" },
                values: new object[] { new DateTime(2026, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Devam Ediyor" });

            migrationBuilder.UpdateData(
                table: "BuildTaskFlowTasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CompletedAt", "DueDate", "StartDate" },
                values: new object[] { new DateTime(2026, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BuildTaskFlowTasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BuildTaskFlowTaskStatusId", "CompletedAt", "DueDate", "ProgressPercentage", "StartDate" },
                values: new object[] { 4, new DateTime(2026, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, new DateTime(2026, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BuildTaskFlowTasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DueDate", "ProgressPercentage", "StartDate" },
                values: new object[] { new DateTime(2026, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 80, new DateTime(2026, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BuildTaskFlowTasks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BuildTaskFlowTaskStatusId", "CompletedAt", "DueDate", "ProgressPercentage", "StartDate" },
                values: new object[] { 4, new DateTime(2026, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, new DateTime(2026, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BuildTaskFlowTasks",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BuildTaskFlowTaskStatusId", "DueDate", "ProgressPercentage", "StartDate" },
                values: new object[] { 3, new DateTime(2026, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 75, new DateTime(2026, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "BuildTaskFlowTasks",
                columns: new[] { "Id", "BuildTaskFlowProjectId", "BuildTaskFlowTaskStatusId", "CompletedAt", "CreatedAt", "Description", "DueDate", "Priority", "ProgressPercentage", "StartDate", "Title" },
                values: new object[,]
                {
                    { 7, 1, 2, null, new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Proje, görev ve ekip üyesi bazlı Gantt görünümü hazırlanacak.", new DateTime(2026, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yüksek", 55, new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gantt ve ilerleme yüzdesi ekranı" },
                    { 8, 1, 3, null, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Migration, rol bazlı erişim ve örnek kullanıcı akışı test edilecek.", new DateTime(2026, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yüksek", 70, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Veritabanı ve rol testleri" },
                    { 9, 2, 2, null, new DateTime(2026, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kişilere göre görev sayısı, tamamlanan görev ve ortalama yüzde değerleri kontrol edilecek.", new DateTime(2026, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Orta", 45, new DateTime(2026, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ekip üyesi bazlı görev raporu" },
                    { 10, 2, 3, null, new DateTime(2026, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sunum sırasında açılacak ekranlar ve örnek veriler uçtan uca test edilecek.", new DateTime(2026, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yüksek", 60, new DateTime(2026, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Final demo testleri" },
                    { 11, 2, 2, null, new DateTime(2026, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gantt, görev yüzdeleri ve rapor ekranlarında kullanılacak demo verileri güncellenecek.", new DateTime(2026, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Orta", 30, new DateTime(2026, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sunum demo verilerini güncelleme" }
                });

            migrationBuilder.InsertData(
                table: "BuildTaskFlowComments",
                columns: new[] { "Id", "BuildTaskFlowTaskId", "BuildTaskFlowTeamMemberId", "CreatedAt", "Text" },
                values: new object[,]
                {
                    { 3, 8, 3, new DateTime(2026, 6, 12, 11, 30, 0, 0, DateTimeKind.Unspecified), "Rol bazlı erişim ve Gantt görünümü test senaryosuna eklendi." },
                    { 4, 10, 2, new DateTime(2026, 6, 14, 15, 45, 0, 0, DateTimeKind.Unspecified), "Final demosunda Gantt tarihleri ve tamamlanma yüzdeleri özellikle gösterilecek." }
                });

            migrationBuilder.InsertData(
                table: "BuildTaskFlowTaskAssignments",
                columns: new[] { "Id", "AssignedAt", "BuildTaskFlowTaskId", "BuildTaskFlowTeamMemberId" },
                values: new object[,]
                {
                    { 7, new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 2 },
                    { 8, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 3 },
                    { 9, new DateTime(2026, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 4 },
                    { 10, new DateTime(2026, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 2 },
                    { 11, new DateTime(2026, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BuildTaskFlowComments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BuildTaskFlowComments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BuildTaskFlowTaskAssignments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BuildTaskFlowTaskAssignments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "BuildTaskFlowTaskAssignments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "BuildTaskFlowTaskAssignments",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "BuildTaskFlowTaskAssignments",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "BuildTaskFlowTasks",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BuildTaskFlowTasks",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "BuildTaskFlowTasks",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "BuildTaskFlowTasks",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "BuildTaskFlowTasks",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.UpdateData(
                table: "BuildTaskFlowProjects",
                keyColumn: "Id",
                keyValue: 1,
                column: "EndDate",
                value: new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "BuildTaskFlowProjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "Status" },
                values: new object[] { new DateTime(2026, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Planlandı" });

            migrationBuilder.UpdateData(
                table: "BuildTaskFlowTasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CompletedAt", "DueDate", "StartDate" },
                values: new object[] { new DateTime(2026, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BuildTaskFlowTasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BuildTaskFlowTaskStatusId", "CompletedAt", "DueDate", "ProgressPercentage", "StartDate" },
                values: new object[] { 2, null, new DateTime(2026, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 65, new DateTime(2026, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BuildTaskFlowTasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DueDate", "ProgressPercentage", "StartDate" },
                values: new object[] { new DateTime(2026, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 85, new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BuildTaskFlowTasks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BuildTaskFlowTaskStatusId", "CompletedAt", "DueDate", "ProgressPercentage", "StartDate" },
                values: new object[] { 1, null, new DateTime(2026, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 35, new DateTime(2026, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BuildTaskFlowTasks",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BuildTaskFlowTaskStatusId", "DueDate", "ProgressPercentage", "StartDate" },
                values: new object[] { 1, new DateTime(2026, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, new DateTime(2026, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
