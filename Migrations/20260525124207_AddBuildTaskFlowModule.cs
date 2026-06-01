using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814

namespace ConstructionManagementSystem.Migrations
{
    public partial class AddBuildTaskFlowModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuildTaskFlowRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildTaskFlowRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BuildTaskFlowTaskStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildTaskFlowTaskStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BuildTaskFlowTeamMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    BuildTaskFlowRoleId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildTaskFlowTeamMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildTaskFlowTeamMembers_BuildTaskFlowRoles_BuildTaskFlowRoleId",
                        column: x => x.BuildTaskFlowRoleId,
                        principalTable: "BuildTaskFlowRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BuildTaskFlowProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    OwnerTeamMemberId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildTaskFlowProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildTaskFlowProjects_BuildTaskFlowTeamMembers_OwnerTeamMemberId",
                        column: x => x.OwnerTeamMemberId,
                        principalTable: "BuildTaskFlowTeamMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "BuildTaskFlowInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    BuildTaskFlowProjectId = table.Column<int>(type: "int", nullable: false),
                    CustomerTitle = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TaxRate = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    GrandTotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildTaskFlowInvoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildTaskFlowInvoices_BuildTaskFlowProjects_BuildTaskFlowProjectId",
                        column: x => x.BuildTaskFlowProjectId,
                        principalTable: "BuildTaskFlowProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BuildTaskFlowTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildTaskFlowProjectId = table.Column<int>(type: "int", nullable: false),
                    BuildTaskFlowTaskStatusId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildTaskFlowTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildTaskFlowTasks_BuildTaskFlowProjects_BuildTaskFlowProjectId",
                        column: x => x.BuildTaskFlowProjectId,
                        principalTable: "BuildTaskFlowProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BuildTaskFlowTasks_BuildTaskFlowTaskStatuses_BuildTaskFlowTaskStatusId",
                        column: x => x.BuildTaskFlowTaskStatusId,
                        principalTable: "BuildTaskFlowTaskStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BuildTaskFlowInvoiceItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildTaskFlowInvoiceId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    LineTotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildTaskFlowInvoiceItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildTaskFlowInvoiceItems_BuildTaskFlowInvoices_BuildTaskFlowInvoiceId",
                        column: x => x.BuildTaskFlowInvoiceId,
                        principalTable: "BuildTaskFlowInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BuildTaskFlowComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildTaskFlowTaskId = table.Column<int>(type: "int", nullable: false),
                    BuildTaskFlowTeamMemberId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(1200)", maxLength: 1200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildTaskFlowComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildTaskFlowComments_BuildTaskFlowTasks_BuildTaskFlowTaskId",
                        column: x => x.BuildTaskFlowTaskId,
                        principalTable: "BuildTaskFlowTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildTaskFlowComments_BuildTaskFlowTeamMembers_BuildTaskFlowTeamMemberId",
                        column: x => x.BuildTaskFlowTeamMemberId,
                        principalTable: "BuildTaskFlowTeamMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BuildTaskFlowTaskAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildTaskFlowTaskId = table.Column<int>(type: "int", nullable: false),
                    BuildTaskFlowTeamMemberId = table.Column<int>(type: "int", nullable: false),
                    AssignedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildTaskFlowTaskAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildTaskFlowTaskAssignments_BuildTaskFlowTasks_BuildTaskFlowTaskId",
                        column: x => x.BuildTaskFlowTaskId,
                        principalTable: "BuildTaskFlowTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildTaskFlowTaskAssignments_BuildTaskFlowTeamMembers_BuildTaskFlowTeamMemberId",
                        column: x => x.BuildTaskFlowTeamMemberId,
                        principalTable: "BuildTaskFlowTeamMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "BuildTaskFlowRoles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Sistemdeki tüm proje yönetimi işlemlerini yapabilir.", "Yönetici" },
                    { 2, "Proje ve görev planını yönetir.", "Proje Sorumlusu" },
                    { 3, "Şantiye projelerini, işçileri ve saha görevlerini takip eder.", "Şantiye Şefi" },
                    { 4, "Malzemeleri, tedarikçileri, stokları ve malzeme alımlarını yönetir.", "Depo / Malzeme Sorumlusu" },
                    { 5, "Proforma/fatura taslaklarını ve ödeme planını takip eder.", "Muhasebe" },
                    { 6, "Sistemi sadece görüntüler.", "Görüntüleyici" }
                });

            migrationBuilder.InsertData(
                table: "BuildTaskFlowTaskStatuses",
                columns: new[] { "Id", "Name", "SortOrder" },
                values: new object[,]
                {
                    { 1, "Yapılacak", 1 },
                    { 2, "Devam Ediyor", 2 },
                    { 3, "Test Ediliyor", 3 },
                    { 4, "Tamamlandı", 4 }
                });

            migrationBuilder.InsertData(
                table: "BuildTaskFlowTeamMembers",
                columns: new[] { "Id", "BuildTaskFlowRoleId", "CreatedAt", "Email", "FullName", "IsActive", "PasswordHash", "Phone" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@buildtaskflow.local", "Admin Kullanıcı", true, "8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92", "0500 100 00 01" },
                    { 2, 2, new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "proje@buildtaskflow.local", "Ece Proje", true, "8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92", "0500 100 00 02" },
                    { 3, 3, new DateTime(2026, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "santiyesefi@buildtaskflow.local", "Mert Şantiye Şefi", true, "8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92", "0500 100 00 03" },
                    { 4, 4, new DateTime(2026, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "depo@buildtaskflow.local", "Selin Depo Sorumlusu", true, "8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92", "0500 100 00 04" },
                    { 5, 5, new DateTime(2026, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "muhasebe@buildtaskflow.local", "Deniz Muhasebe", true, "8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92", "0500 100 00 05" }
                });

            migrationBuilder.InsertData(
                table: "BuildTaskFlowProjects",
                columns: new[] { "Id", "Description", "EndDate", "Name", "OwnerTeamMemberId", "StartDate", "Status" },
                values: new object[,]
                {
                    { 1, "Şantiye, malzeme, işçi, gelir ve gider ekranlarının geliştirme planı.", new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "İnşaat Otomasyonu Geliştirme Projesi", 2, new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Devam Ediyor" },
                    { 2, "Saha ekiplerinin görev, durum ve teslim tarihlerini takip etmesi için proje yönetimi kurulumu.", new DateTime(2026, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Şantiye Görev Takip Kurulumu", 2, new DateTime(2026, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Planlandı" }
                });

            migrationBuilder.InsertData(
                table: "BuildTaskFlowInvoices",
                columns: new[] { "Id", "BuildTaskFlowProjectId", "CustomerTitle", "DueDate", "GrandTotal", "InvoiceDate", "InvoiceNumber", "Notes", "Status", "SubTotal", "TaxAmount", "TaxRate" },
                values: new object[] { 1, 1, "Yılmaz Apartman Yönetimi", new DateTime(2026, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 180000m, new DateTime(2026, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "PRF-2026-001", "Bu kayıt resmi fatura değil, operasyon takibi için hazırlanmış proforma/fatura taslağıdır.", "Taslak", 150000m, 30000m, 20m });

            migrationBuilder.InsertData(
                table: "BuildTaskFlowTasks",
                columns: new[] { "Id", "BuildTaskFlowProjectId", "BuildTaskFlowTaskStatusId", "CompletedAt", "CreatedAt", "Description", "DueDate", "Priority", "Title" },
                values: new object[,]
                {
                    { 1, 1, 4, new DateTime(2026, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ana tablolar, ilişkiler ve seed verileri planlanacak.", new DateTime(2026, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yüksek", "Veritabanı tablolarını tasarlama" },
                    { 2, 1, 4, new DateTime(2026, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Şantiye/proje kaydı için model ve CRUD ekranları hazırlanacak.", new DateTime(2026, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yüksek", "ConstructionProject modelini oluşturma" },
                    { 3, 1, 2, null, new DateTime(2026, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malzeme alımı yapıldığında stok miktarını artıran iş kuralı uygulanacak.", new DateTime(2026, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yüksek", "MaterialPurchase işlemini oluşturma" },
                    { 4, 1, 3, null, new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Toplam proje, gelir, gider ve net kar/zarar kartları kontrol edilecek.", new DateTime(2026, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Orta", "Dashboard tasarımı" },
                    { 5, 2, 1, null, new DateTime(2026, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yönetici, proje sorumlusu, şantiye şefi, malzeme sorumlusu ve muhasebe rollerinin giriş akışı hazırlanacak.", new DateTime(2026, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yüksek", "Rol ve giriş ekranı tasarımı" },
                    { 6, 2, 1, null, new DateTime(2026, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tarihli, numaralı ve kalemli proforma/fatura taslağı ekranı hazırlanacak.", new DateTime(2026, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Orta", "Proforma fatura taslağı ekranı" }
                });

            migrationBuilder.InsertData(
                table: "BuildTaskFlowComments",
                columns: new[] { "Id", "BuildTaskFlowTaskId", "BuildTaskFlowTeamMemberId", "CreatedAt", "Text" },
                values: new object[,]
                {
                    { 1, 3, 2, new DateTime(2026, 5, 20, 10, 30, 0, 0, DateTimeKind.Unspecified), "Stok artışı iş kuralı süreç takibinde özellikle kontrol edilecek." },
                    { 2, 4, 4, new DateTime(2026, 5, 22, 14, 15, 0, 0, DateTimeKind.Unspecified), "Dashboard kartları test edildi, tarih ve para gösterimleri kontrol edilecek." }
                });

            migrationBuilder.InsertData(
                table: "BuildTaskFlowInvoiceItems",
                columns: new[] { "Id", "BuildTaskFlowInvoiceId", "Description", "LineTotal", "Quantity", "UnitPrice" },
                values: new object[] { 1, 1, "Şantiye yönetim sistemi geliştirme hizmeti", 150000m, 1m, 150000m });

            migrationBuilder.InsertData(
                table: "BuildTaskFlowTaskAssignments",
                columns: new[] { "Id", "AssignedAt", "BuildTaskFlowTaskId", "BuildTaskFlowTeamMemberId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 2, new DateTime(2026, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3 },
                    { 3, new DateTime(2026, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3 },
                    { 4, new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4 },
                    { 5, new DateTime(2026, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 2 },
                    { 6, new DateTime(2026, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuildTaskFlowComments_BuildTaskFlowTaskId",
                table: "BuildTaskFlowComments",
                column: "BuildTaskFlowTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildTaskFlowComments_BuildTaskFlowTeamMemberId",
                table: "BuildTaskFlowComments",
                column: "BuildTaskFlowTeamMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildTaskFlowInvoiceItems_BuildTaskFlowInvoiceId",
                table: "BuildTaskFlowInvoiceItems",
                column: "BuildTaskFlowInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildTaskFlowInvoices_BuildTaskFlowProjectId",
                table: "BuildTaskFlowInvoices",
                column: "BuildTaskFlowProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildTaskFlowInvoices_InvoiceNumber",
                table: "BuildTaskFlowInvoices",
                column: "InvoiceNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BuildTaskFlowProjects_OwnerTeamMemberId",
                table: "BuildTaskFlowProjects",
                column: "OwnerTeamMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildTaskFlowRoles_Name",
                table: "BuildTaskFlowRoles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BuildTaskFlowTaskAssignments_BuildTaskFlowTaskId_BuildTaskFlowTeamMemberId",
                table: "BuildTaskFlowTaskAssignments",
                columns: new[] { "BuildTaskFlowTaskId", "BuildTaskFlowTeamMemberId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BuildTaskFlowTaskAssignments_BuildTaskFlowTeamMemberId",
                table: "BuildTaskFlowTaskAssignments",
                column: "BuildTaskFlowTeamMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildTaskFlowTasks_BuildTaskFlowProjectId",
                table: "BuildTaskFlowTasks",
                column: "BuildTaskFlowProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildTaskFlowTasks_BuildTaskFlowTaskStatusId",
                table: "BuildTaskFlowTasks",
                column: "BuildTaskFlowTaskStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildTaskFlowTeamMembers_BuildTaskFlowRoleId",
                table: "BuildTaskFlowTeamMembers",
                column: "BuildTaskFlowRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildTaskFlowTeamMembers_Email",
                table: "BuildTaskFlowTeamMembers",
                column: "Email",
                unique: true);
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuildTaskFlowComments");

            migrationBuilder.DropTable(
                name: "BuildTaskFlowInvoiceItems");

            migrationBuilder.DropTable(
                name: "BuildTaskFlowTaskAssignments");

            migrationBuilder.DropTable(
                name: "BuildTaskFlowInvoices");

            migrationBuilder.DropTable(
                name: "BuildTaskFlowTasks");

            migrationBuilder.DropTable(
                name: "BuildTaskFlowProjects");

            migrationBuilder.DropTable(
                name: "BuildTaskFlowTaskStatuses");

            migrationBuilder.DropTable(
                name: "BuildTaskFlowTeamMembers");

            migrationBuilder.DropTable(
                name: "BuildTaskFlowRoles");
        }
    }
}
