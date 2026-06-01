using System;
using ConstructionManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConstructionManagementSystem.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20260517210124_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "10.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ConstructionManagementSystem.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "İstanbul / Kadıköy",
                            CompanyName = "Yılmaz Apartman Yönetimi",
                            FullName = "Mehmet Yılmaz",
                            Phone = "0532 111 22 33"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Ankara / Çankaya",
                            CompanyName = "Demir Gayrimenkul A.Ş.",
                            FullName = "Ayşe Demir",
                            Phone = "0541 222 33 44"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Bursa / Nilüfer",
                            CompanyName = "Kaya Lojistik Ltd.",
                            FullName = "Hasan Kaya",
                            Phone = "0555 333 44 55"
                        });
                });

            modelBuilder.Entity("ConstructionManagementSystem.Models.ConstructionProject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<decimal>("ContractAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(160)
                        .HasColumnType("nvarchar(160)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("ConstructionProjects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClientId = 1,
                            ContractAmount = 8500000m,
                            Description = "12 daireli konut inşaatı ve çevre düzenleme işi.",
                            Location = "İstanbul / Kadıköy",
                            Name = "Kadıköy Konut Şantiyesi",
                            StartDate = new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Aktif"
                        },
                        new
                        {
                            Id = 2,
                            ClientId = 3,
                            ContractAmount = 4250000m,
                            Description = "Mevcut depo binası güçlendirme ve tesisat yenileme işi.",
                            EndDate = new DateTime(2026, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Location = "Bursa / Nilüfer",
                            Name = "Nilüfer Depo Güçlendirme",
                            StartDate = new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Tamamlandı"
                        });
                });

            modelBuilder.Entity("ConstructionManagementSystem.Models.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("ConstructionProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("ExpenseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("Id");

                    b.HasIndex("ConstructionProjectId");

                    b.ToTable("Expenses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 18500m,
                            Category = "Yemek",
                            ConstructionProjectId = 1,
                            Description = "Şubat ayı personel yemek gideri.",
                            ExpenseDate = new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Şantiye yemek gideri"
                        },
                        new
                        {
                            Id = 2,
                            Amount = 9500m,
                            Category = "Nakliye",
                            ConstructionProjectId = 1,
                            Description = "Beton dökümü için pompa ve nakliye hizmeti.",
                            ExpenseDate = new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Beton pompası nakliye"
                        },
                        new
                        {
                            Id = 3,
                            Amount = 7200m,
                            Category = "Yakıt",
                            ConstructionProjectId = 1,
                            Description = "Şantiye jeneratörü mazot alımı.",
                            ExpenseDate = new DateTime(2026, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Jeneratör yakıtı"
                        },
                        new
                        {
                            Id = 4,
                            Amount = 4300m,
                            Category = "Elektrik",
                            ConstructionProjectId = 2,
                            Description = "Depo güçlendirme elektrik tüketimi.",
                            ExpenseDate = new DateTime(2026, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Şantiye elektrik faturası"
                        },
                        new
                        {
                            Id = 5,
                            Amount = 6200m,
                            Category = "Bakım",
                            ConstructionProjectId = 2,
                            Description = "Saha ekipmanı bakım işlemi.",
                            ExpenseDate = new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Kompresör bakım gideri"
                        });
                });

            modelBuilder.Entity("ConstructionManagementSystem.Models.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("MaterialTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<decimal>("StockQuantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("MaterialTypeId");

                    b.ToTable("Materials");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Temel ve kolon betonlarında kullanılır.",
                            MaterialTypeId = 1,
                            Name = "C30 Hazır Beton",
                            StockQuantity = 120m,
                            Unit = "m³",
                            UnitPrice = 2450m
                        },
                        new
                        {
                            Id = 2,
                            Description = "Taşıyıcı donatı demiri.",
                            MaterialTypeId = 2,
                            Name = "12'lik İnşaat Demiri",
                            StockQuantity = 15m,
                            Unit = "ton",
                            UnitPrice = 26500m
                        },
                        new
                        {
                            Id = 3,
                            Description = "Etriye ve yardımcı donatı işleri.",
                            MaterialTypeId = 2,
                            Name = "8'lik İnşaat Demiri",
                            StockQuantity = 0m,
                            Unit = "ton",
                            UnitPrice = 25500m
                        },
                        new
                        {
                            Id = 4,
                            Description = "Duvar imalatı için standart tuğla.",
                            MaterialTypeId = 3,
                            Name = "Tuğla",
                            StockQuantity = 0m,
                            Unit = "adet",
                            UnitPrice = 8m
                        },
                        new
                        {
                            Id = 5,
                            Description = "Sıva, şap ve küçük beton işleri.",
                            MaterialTypeId = 5,
                            Name = "Çimento",
                            StockQuantity = 500m,
                            Unit = "torba",
                            UnitPrice = 185m
                        },
                        new
                        {
                            Id = 6,
                            Description = "Kalıp kurulumlarında kullanılır.",
                            MaterialTypeId = 4,
                            Name = "Kalıp Tahtası",
                            StockQuantity = 0m,
                            Unit = "adet",
                            UnitPrice = 320m
                        },
                        new
                        {
                            Id = 7,
                            Description = "İç tesisat elektrik kablosu.",
                            MaterialTypeId = 6,
                            Name = "Elektrik Kablosu",
                            StockQuantity = 0m,
                            Unit = "metre",
                            UnitPrice = 42m
                        },
                        new
                        {
                            Id = 8,
                            Description = "Temiz ve pis su tesisatı için PVC boru.",
                            MaterialTypeId = 7,
                            Name = "PVC Boru",
                            StockQuantity = 0m,
                            Unit = "metre",
                            UnitPrice = 65m
                        });
                });

            modelBuilder.Entity("ConstructionManagementSystem.Models.MaterialPurchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ConstructionProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ConstructionProjectId");

                    b.HasIndex("MaterialId");

                    b.HasIndex("SupplierId");

                    b.ToTable("MaterialPurchases");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConstructionProjectId = 1,
                            Description = "Temel betonu için ilk sevkiyat.",
                            MaterialId = 1,
                            PurchaseDate = new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quantity = 120m,
                            SupplierId = 1,
                            TotalAmount = 294000m,
                            UnitPrice = 2450m
                        },
                        new
                        {
                            Id = 2,
                            ConstructionProjectId = 1,
                            Description = "Radye temel ve kolon donatısı.",
                            MaterialId = 2,
                            PurchaseDate = new DateTime(2026, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quantity = 15m,
                            SupplierId = 2,
                            TotalAmount = 397500m,
                            UnitPrice = 26500m
                        },
                        new
                        {
                            Id = 3,
                            ConstructionProjectId = 2,
                            Description = "Güçlendirme sıva ve şap işleri.",
                            MaterialId = 5,
                            PurchaseDate = new DateTime(2026, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Quantity = 500m,
                            SupplierId = 3,
                            TotalAmount = 92500m,
                            UnitPrice = 185m
                        });
                });

            modelBuilder.Entity("ConstructionManagementSystem.Models.MaterialType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.ToTable("MaterialTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Beton"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Demir"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Tuğla"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Kalıp"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Çimento"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Elektrik Malzemesi"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Sıhhi Tesisat Malzemesi"
                        });
                });

            modelBuilder.Entity("ConstructionManagementSystem.Models.ProjectIncome", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ConstructionProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("IncomeDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ConstructionProjectId");

                    b.ToTable("ProjectIncomes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 1250000m,
                            ConstructionProjectId = 1,
                            Description = "Birinci hakediş tahsilatı.",
                            IncomeDate = new DateTime(2026, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Amount = 1750000m,
                            ConstructionProjectId = 1,
                            Description = "İkinci hakediş tahsilatı.",
                            IncomeDate = new DateTime(2026, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Amount = 4250000m,
                            ConstructionProjectId = 2,
                            Description = "Proje kapanış tahsilatı.",
                            IncomeDate = new DateTime(2026, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ConstructionManagementSystem.Models.Subcontractor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("WorkType")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.ToTable("Subcontractors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "İstanbul / Pendik",
                            CompanyName = "Usta Demir Donatı",
                            ContactName = "Kemal Usta",
                            Phone = "0533 410 20 10",
                            WorkType = "Demirci"
                        },
                        new
                        {
                            Id = 2,
                            Address = "İstanbul / Kartal",
                            CompanyName = "Sağlam Kalıp Sistemleri",
                            ContactName = "Murat Sağlam",
                            Phone = "0534 420 20 10",
                            WorkType = "Kalıpçı"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Ankara / Yenimahalle",
                            CompanyName = "Parlak Elektrik Taahhüt",
                            ContactName = "Emre Parlak",
                            Phone = "0535 430 20 10",
                            WorkType = "Elektrik"
                        },
                        new
                        {
                            Id = 4,
                            Address = "Bursa / Nilüfer",
                            CompanyName = "Akış Tesisat",
                            ContactName = "Selim Akış",
                            Phone = "0536 440 20 10",
                            WorkType = "Sıhhi Tesisat"
                        });
                });

            modelBuilder.Entity("ConstructionManagementSystem.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "İstanbul / Tuzla",
                            CompanyName = "Marmara Beton Sanayi",
                            ContactName = "Ali Betoncu",
                            Phone = "0216 444 10 10"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Ankara / Sincan",
                            CompanyName = "Anadolu Demir Çelik",
                            ContactName = "Fatma Çelik",
                            Phone = "0312 555 20 20"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Bursa / Osmangazi",
                            CompanyName = "Güven Yapı Market",
                            ContactName = "Mustafa Şahin",
                            Phone = "0224 666 30 30"
                        },
                        new
                        {
                            Id = 4,
                            Address = "İstanbul / Bayrampaşa",
                            CompanyName = "Eksen Elektrik Malzemeleri",
                            ContactName = "Zeynep Aksoy",
                            Phone = "0212 777 40 40"
                        });
                });

            modelBuilder.Entity("ConstructionManagementSystem.Models.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("DailyWage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Workers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DailyWage = 1800m,
                            FullName = "Ahmet Usta",
                            IsActive = true,
                            JobTitle = "Usta",
                            Phone = "0532 500 10 10"
                        },
                        new
                        {
                            Id = 2,
                            DailyWage = 1400m,
                            FullName = "Mehmet Kalfa",
                            IsActive = true,
                            JobTitle = "Kalfa",
                            Phone = "0532 500 10 11"
                        },
                        new
                        {
                            Id = 3,
                            DailyWage = 1100m,
                            FullName = "Hasan İşçi",
                            IsActive = true,
                            JobTitle = "İnşaat işçisi",
                            Phone = "0532 500 10 12"
                        },
                        new
                        {
                            Id = 4,
                            DailyWage = 1700m,
                            FullName = "Ali Elektrikçi",
                            IsActive = true,
                            JobTitle = "Elektrik ustası",
                            Phone = "0532 500 10 13"
                        },
                        new
                        {
                            Id = 5,
                            DailyWage = 1650m,
                            FullName = "Serkan Tesisatçı",
                            IsActive = true,
                            JobTitle = "Tesisat ustası",
                            Phone = "0532 500 10 14"
                        });
                });

            modelBuilder.Entity("ConstructionManagementSystem.Models.WorkerPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ConstructionProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("WorkDays")
                        .HasColumnType("int");

                    b.Property<int>("WorkerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ConstructionProjectId");

                    b.HasIndex("WorkerId");

                    b.ToTable("WorkerPayments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 21600m,
                            ConstructionProjectId = 1,
                            Description = "Şubat ayı kaba inşaat ustalık ödemesi.",
                            PaymentDate = new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            WorkDays = 12,
                            WorkerId = 1
                        },
                        new
                        {
                            Id = 2,
                            Amount = 16500m,
                            ConstructionProjectId = 1,
                            Description = "Şubat ayı yardımcı işçi ödemesi.",
                            PaymentDate = new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            WorkDays = 15,
                            WorkerId = 3
                        },
                        new
                        {
                            Id = 3,
                            Amount = 13600m,
                            ConstructionProjectId = 2,
                            Description = "Depo elektrik tesisatı yenileme ödemesi.",
                            PaymentDate = new DateTime(2026, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            WorkDays = 8,
                            WorkerId = 4
                        });
                });

            modelBuilder.Entity("ConstructionManagementSystem.Models.ConstructionProject", b =>
                {
                    b.HasOne("ConstructionManagementSystem.Models.Client", "Client")
                        .WithMany("ConstructionProjects")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("ConstructionManagementSystem.Models.Expense", b =>
                {
                    b.HasOne("ConstructionManagementSystem.Models.ConstructionProject", "ConstructionProject")
                        .WithMany("Expenses")
                        .HasForeignKey("ConstructionProjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ConstructionProject");
                });

            modelBuilder.Entity("ConstructionManagementSystem.Models.Material", b =>
                {
                    b.HasOne("ConstructionManagementSystem.Models.MaterialType", "MaterialType")
                        .WithMany("Materials")
                        .HasForeignKey("MaterialTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("MaterialType");
                });

            modelBuilder.Entity("ConstructionManagementSystem.Models.MaterialPurchase", b =>
                {
                    b.HasOne("ConstructionManagementSystem.Models.ConstructionProject", "ConstructionProject")
                        .WithMany("MaterialPurchases")
                        .HasForeignKey("ConstructionProjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ConstructionManagementSystem.Models.Material", "Material")
                        .WithMany("MaterialPurchases")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ConstructionManagementSystem.Models.Supplier", "Supplier")
                        .WithMany("MaterialPurchases")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ConstructionProject");

                    b.Navigation("Material");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("ConstructionManagementSystem.Models.ProjectIncome", b =>
                {
                    b.HasOne("ConstructionManagementSystem.Models.ConstructionProject", "ConstructionProject")
                        .WithMany("ProjectIncomes")
                        .HasForeignKey("ConstructionProjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ConstructionProject");
                });

            modelBuilder.Entity("ConstructionManagementSystem.Models.WorkerPayment", b =>
                {
                    b.HasOne("ConstructionManagementSystem.Models.ConstructionProject", "ConstructionProject")
                        .WithMany("WorkerPayments")
                        .HasForeignKey("ConstructionProjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ConstructionManagementSystem.Models.Worker", "Worker")
                        .WithMany("WorkerPayments")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ConstructionProject");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("ConstructionManagementSystem.Models.Client", b =>
                {
                    b.Navigation("ConstructionProjects");
                });

            modelBuilder.Entity("ConstructionManagementSystem.Models.ConstructionProject", b =>
                {
                    b.Navigation("Expenses");

                    b.Navigation("MaterialPurchases");

                    b.Navigation("ProjectIncomes");

                    b.Navigation("WorkerPayments");
                });

            modelBuilder.Entity("ConstructionManagementSystem.Models.Material", b =>
                {
                    b.Navigation("MaterialPurchases");
                });

            modelBuilder.Entity("ConstructionManagementSystem.Models.MaterialType", b =>
                {
                    b.Navigation("Materials");
                });

            modelBuilder.Entity("ConstructionManagementSystem.Models.Supplier", b =>
                {
                    b.Navigation("MaterialPurchases");
                });

            modelBuilder.Entity("ConstructionManagementSystem.Models.Worker", b =>
                {
                    b.Navigation("WorkerPayments");
                });
#pragma warning restore 612, 618
        }
    }
}
