using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConstructionManagementSystem.Migrations
{
    public partial class CleanProductWording : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BuildTaskFlowTasks",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "Yönetici, proje sorumlusu, şantiye şefi, malzeme sorumlusu ve muhasebe rollerinin giriş akışı hazırlanacak.");

            migrationBuilder.UpdateData(
                table: "BuildTaskFlowComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Text",
                value: "Stok artışı iş kuralı süreç takibinde özellikle kontrol edilecek.");

            migrationBuilder.UpdateData(
                table: "BuildTaskFlowInvoices",
                keyColumn: "Id",
                keyValue: 1,
                column: "Notes",
                value: "Bu kayıt resmi fatura değil, operasyon takibi için hazırlanmış proforma/fatura taslağıdır.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
