using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814

namespace ConstructionManagementSystem.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaterialTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subcontractors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    WorkType = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcontractors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    DailyWage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConstructionProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ContractAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstructionProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConstructionProjects_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    MaterialTypeId = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materials_MaterialTypes_MaterialTypeId",
                        column: x => x.MaterialTypeId,
                        principalTable: "MaterialTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConstructionProjectId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExpenseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_ConstructionProjects_ConstructionProjectId",
                        column: x => x.ConstructionProjectId,
                        principalTable: "ConstructionProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectIncomes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConstructionProjectId = table.Column<int>(type: "int", nullable: false),
                    IncomeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectIncomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectIncomes_ConstructionProjects_ConstructionProjectId",
                        column: x => x.ConstructionProjectId,
                        principalTable: "ConstructionProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkerPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkerId = table.Column<int>(type: "int", nullable: false),
                    ConstructionProjectId = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkDays = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkerPayments_ConstructionProjects_ConstructionProjectId",
                        column: x => x.ConstructionProjectId,
                        principalTable: "ConstructionProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkerPayments_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaterialPurchases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConstructionProjectId = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialPurchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialPurchases_ConstructionProjects_ConstructionProjectId",
                        column: x => x.ConstructionProjectId,
                        principalTable: "ConstructionProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaterialPurchases_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaterialPurchases_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Address", "CompanyName", "FullName", "Phone" },
                values: new object[,]
                {
                    { 1, "İstanbul / Kadıköy", "Yılmaz Apartman Yönetimi", "Mehmet Yılmaz", "0532 111 22 33" },
                    { 2, "Ankara / Çankaya", "Demir Gayrimenkul A.Ş.", "Ayşe Demir", "0541 222 33 44" },
                    { 3, "Bursa / Nilüfer", "Kaya Lojistik Ltd.", "Hasan Kaya", "0555 333 44 55" }
                });

            migrationBuilder.InsertData(
                table: "MaterialTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Beton" },
                    { 2, "Demir" },
                    { 3, "Tuğla" },
                    { 4, "Kalıp" },
                    { 5, "Çimento" },
                    { 6, "Elektrik Malzemesi" },
                    { 7, "Sıhhi Tesisat Malzemesi" }
                });

            migrationBuilder.InsertData(
                table: "Subcontractors",
                columns: new[] { "Id", "Address", "CompanyName", "ContactName", "Phone", "WorkType" },
                values: new object[,]
                {
                    { 1, "İstanbul / Pendik", "Usta Demir Donatı", "Kemal Usta", "0533 410 20 10", "Demirci" },
                    { 2, "İstanbul / Kartal", "Sağlam Kalıp Sistemleri", "Murat Sağlam", "0534 420 20 10", "Kalıpçı" },
                    { 3, "Ankara / Yenimahalle", "Parlak Elektrik Taahhüt", "Emre Parlak", "0535 430 20 10", "Elektrik" },
                    { 4, "Bursa / Nilüfer", "Akış Tesisat", "Selim Akış", "0536 440 20 10", "Sıhhi Tesisat" }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Address", "CompanyName", "ContactName", "Phone" },
                values: new object[,]
                {
                    { 1, "İstanbul / Tuzla", "Marmara Beton Sanayi", "Ali Betoncu", "0216 444 10 10" },
                    { 2, "Ankara / Sincan", "Anadolu Demir Çelik", "Fatma Çelik", "0312 555 20 20" },
                    { 3, "Bursa / Osmangazi", "Güven Yapı Market", "Mustafa Şahin", "0224 666 30 30" },
                    { 4, "İstanbul / Bayrampaşa", "Eksen Elektrik Malzemeleri", "Zeynep Aksoy", "0212 777 40 40" }
                });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "Id", "DailyWage", "FullName", "IsActive", "JobTitle", "Phone" },
                values: new object[,]
                {
                    { 1, 1800m, "Ahmet Usta", true, "Usta", "0532 500 10 10" },
                    { 2, 1400m, "Mehmet Kalfa", true, "Kalfa", "0532 500 10 11" },
                    { 3, 1100m, "Hasan İşçi", true, "İnşaat işçisi", "0532 500 10 12" },
                    { 4, 1700m, "Ali Elektrikçi", true, "Elektrik ustası", "0532 500 10 13" },
                    { 5, 1650m, "Serkan Tesisatçı", true, "Tesisat ustası", "0532 500 10 14" }
                });

            migrationBuilder.InsertData(
                table: "ConstructionProjects",
                columns: new[] { "Id", "ClientId", "ContractAmount", "Description", "EndDate", "Location", "Name", "StartDate", "Status" },
                values: new object[,]
                {
                    { 1, 1, 8500000m, "12 daireli konut inşaatı ve çevre düzenleme işi.", null, "İstanbul / Kadıköy", "Kadıköy Konut Şantiyesi", new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aktif" },
                    { 2, 3, 4250000m, "Mevcut depo binası güçlendirme ve tesisat yenileme işi.", new DateTime(2026, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bursa / Nilüfer", "Nilüfer Depo Güçlendirme", new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tamamlandı" }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "Description", "MaterialTypeId", "Name", "StockQuantity", "Unit", "UnitPrice" },
                values: new object[,]
                {
                    { 1, "Temel ve kolon betonlarında kullanılır.", 1, "C30 Hazır Beton", 120m, "m³", 2450m },
                    { 2, "Taşıyıcı donatı demiri.", 2, "12'lik İnşaat Demiri", 15m, "ton", 26500m },
                    { 3, "Etriye ve yardımcı donatı işleri.", 2, "8'lik İnşaat Demiri", 0m, "ton", 25500m },
                    { 4, "Duvar imalatı için standart tuğla.", 3, "Tuğla", 0m, "adet", 8m },
                    { 5, "Sıva, şap ve küçük beton işleri.", 5, "Çimento", 500m, "torba", 185m },
                    { 6, "Kalıp kurulumlarında kullanılır.", 4, "Kalıp Tahtası", 0m, "adet", 320m },
                    { 7, "İç tesisat elektrik kablosu.", 6, "Elektrik Kablosu", 0m, "metre", 42m },
                    { 8, "Temiz ve pis su tesisatı için PVC boru.", 7, "PVC Boru", 0m, "metre", 65m }
                });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "Amount", "Category", "ConstructionProjectId", "Description", "ExpenseDate", "Title" },
                values: new object[,]
                {
                    { 1, 18500m, "Yemek", 1, "Şubat ayı personel yemek gideri.", new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Şantiye yemek gideri" },
                    { 2, 9500m, "Nakliye", 1, "Beton dökümü için pompa ve nakliye hizmeti.", new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Beton pompası nakliye" },
                    { 3, 7200m, "Yakıt", 1, "Şantiye jeneratörü mazot alımı.", new DateTime(2026, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jeneratör yakıtı" },
                    { 4, 4300m, "Elektrik", 2, "Depo güçlendirme elektrik tüketimi.", new DateTime(2026, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Şantiye elektrik faturası" },
                    { 5, 6200m, "Bakım", 2, "Saha ekipmanı bakım işlemi.", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kompresör bakım gideri" }
                });

            migrationBuilder.InsertData(
                table: "MaterialPurchases",
                columns: new[] { "Id", "ConstructionProjectId", "Description", "MaterialId", "PurchaseDate", "Quantity", "SupplierId", "TotalAmount", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, "Temel betonu için ilk sevkiyat.", 1, new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 120m, 1, 294000m, 2450m },
                    { 2, 1, "Radye temel ve kolon donatısı.", 2, new DateTime(2026, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 15m, 2, 397500m, 26500m },
                    { 3, 2, "Güçlendirme sıva ve şap işleri.", 5, new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 500m, 3, 92500m, 185m }
                });

            migrationBuilder.InsertData(
                table: "ProjectIncomes",
                columns: new[] { "Id", "Amount", "ConstructionProjectId", "Description", "IncomeDate" },
                values: new object[,]
                {
                    { 1, 1250000m, 1, "Birinci hakediş tahsilatı.", new DateTime(2026, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1750000m, 1, "İkinci hakediş tahsilatı.", new DateTime(2026, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 4250000m, 2, "Proje kapanış tahsilatı.", new DateTime(2026, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "WorkerPayments",
                columns: new[] { "Id", "Amount", "ConstructionProjectId", "Description", "PaymentDate", "WorkDays", "WorkerId" },
                values: new object[,]
                {
                    { 1, 21600m, 1, "Şubat ayı kaba inşaat ustalık ödemesi.", new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 1 },
                    { 2, 16500m, 1, "Şubat ayı yardımcı işçi ödemesi.", new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 3 },
                    { 3, 13600m, 2, "Depo elektrik tesisatı yenileme ödemesi.", new DateTime(2026, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConstructionProjects_ClientId",
                table: "ConstructionProjects",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ConstructionProjectId",
                table: "Expenses",
                column: "ConstructionProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialPurchases_ConstructionProjectId",
                table: "MaterialPurchases",
                column: "ConstructionProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialPurchases_MaterialId",
                table: "MaterialPurchases",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialPurchases_SupplierId",
                table: "MaterialPurchases",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_MaterialTypeId",
                table: "Materials",
                column: "MaterialTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectIncomes_ConstructionProjectId",
                table: "ProjectIncomes",
                column: "ConstructionProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerPayments_ConstructionProjectId",
                table: "WorkerPayments",
                column: "ConstructionProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerPayments_WorkerId",
                table: "WorkerPayments",
                column: "WorkerId");
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "MaterialPurchases");

            migrationBuilder.DropTable(
                name: "ProjectIncomes");

            migrationBuilder.DropTable(
                name: "Subcontractors");

            migrationBuilder.DropTable(
                name: "WorkerPayments");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "ConstructionProjects");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "MaterialTypes");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
