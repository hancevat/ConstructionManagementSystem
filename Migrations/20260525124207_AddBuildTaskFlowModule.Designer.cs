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
    [Migration("20260525124207_AddBuildTaskFlowModule")]
    partial class AddBuildTaskFlowModule
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "10.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ConstructionManagementSystem.Models.BuildTaskFlowComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BuildTaskFlowTaskId")
                        .HasColumnType("int");

                    b.Property<int>("BuildTaskFlowTeamMemberId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(1200)
                        .HasColumnType("nvarchar(1200)");

                    b.HasKey("Id");

                    b.HasIndex("BuildTaskFlowTaskId");

                    b.HasIndex("BuildTaskFlowTeamMemberId");

                    b.ToTable("BuildTaskFlowComments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BuildTaskFlowTaskId = 3,
                            BuildTaskFlowTeamMemberId = 2,
                            CreatedAt = new DateTime(2026, 5, 20, 10, 30, 0, 0, DateTimeKind.Unspecified),
                            Text = "Stok artışı iş kuralı süreç takibinde özellikle kontrol edilecek."
                        },
                        new
                        {
                            Id = 2,
                            BuildTaskFlowTaskId = 4,
                            BuildTaskFlowTeamMemberId = 4,
                            CreatedAt = new DateTime(2026, 5, 22, 14, 15, 0, 0, DateTimeKind.Unspecified),
                            Text = "Dashboard kartları test edildi, tarih ve para gösterimleri kontrol edilecek."
                        });
                });

            modelBuilder.Entity("ConstructionManagementSystem.Models.BuildTaskFlowInvoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BuildTaskFlowProjectId")
                        .HasColumnType("int");

                    b.Property<string>("CustomerTitle")
                        .IsRequired()
                        .HasMaxLength(160)
                        .HasColumnType("nvarchar(160)");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("GrandTotal")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InvoiceNumber")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Notes")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<decimal>("SubTotal")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TaxAmount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TaxRate")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.HasIndex("BuildTaskFlowProjectId");

                    b.HasIndex("InvoiceNumber")
                        .IsUnique();

                    b.ToTable("BuildTaskFlowInvoices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BuildTaskFlowProjectId = 1,
                            CustomerTitle = "Yılmaz Apartman Yönetimi",
                            DueDate = new DateTime(2026, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GrandTotal = 180000m,
                            InvoiceDate = new DateTime(2026, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            InvoiceNumber = "PRF-2026-001",
                            Notes = "Bu kayıt resmi fatura değil, operasyon takibi için hazırlanmış proforma/fatura taslağıdır.",
                            Status = "Taslak",
                            SubTotal = 150000m,
                            TaxAmount = 30000m,
                            TaxRate = 20m
                        });
                });

            modelBuilder.Entity("ConstructionManagementSystem.Models.BuildTaskFlowInvoiceItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BuildTaskFlowInvoiceId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<decimal>("LineTotal")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Quantity")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("UnitPrice")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BuildTaskFlowInvoiceId");

                    b.ToTable("BuildTaskFlowInvoiceItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BuildTaskFlowInvoiceId = 1,
                            Description = "Şantiye yönetim sistemi geliştirme hizmeti",
                            LineTotal = 150000m,
                            Quantity = 1m,
                            UnitPrice = 150000m
                        });
                });

            modelBuilder.Entity("ConstructionManagementSystem.Models.BuildTaskFlowProject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("OwnerTeamMemberId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerTeamMemberId");

                    b.ToTable("BuildTaskFlowProjects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Şantiye, malzeme, işçi, gelir ve gider ekranlarının geliştirme planı.",
                            EndDate = new DateTime(2026, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "İnşaat Otomasyonu Geliştirme Projesi",
                            OwnerTeamMemberId = 2,
                            StartDate = new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Devam Ediyor"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Saha ekiplerinin görev, durum ve teslim tarihlerini takip etmesi için proje yönetimi kurulumu.",
                            EndDate = new DateTime(2026, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Şantiye Görev Takip Kurulumu",
                            OwnerTeamMemberId = 2,
                            StartDate = new DateTime(2026, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Planlandı"
                        });
                });

            modelBuilder.Entity("ConstructionManagementSystem.Models.BuildTaskFlowRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("BuildTaskFlowRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Sistemdeki tüm proje yönetimi işlemlerini yapabilir.",
                            Name = "Yönetici"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Proje ve görev planını yönetir.",
                            Name = "Proje Sorumlusu"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Şantiye projelerini, işçileri ve saha görevlerini takip eder.",
                            Name = "Şantiye Şefi"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Malzemeleri, tedarikçileri, stokları ve malzeme alımlarını yönetir.",
                            Name = "Depo / Malzeme Sorumlusu"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Proforma/fatura taslaklarını ve ödeme planını takip eder.",
                            Name = "Muhasebe"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Sistemi sadece görüntüler.",
                            Name = "Görüntüleyici"
                        });
                });

            modelBuilder.Entity("ConstructionManagementSystem.Models.BuildTaskFlowTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BuildTaskFlowProjectId")
                        .HasColumnType("int");

                    b.Property<int>("BuildTaskFlowTaskStatusId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CompletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Priority")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(180)
                        .HasColumnType("nvarchar(180)");

                    b.HasKey("Id");

                    b.HasIndex("BuildTaskFlowProjectId");

                    b.HasIndex("BuildTaskFlowTaskStatusId");

                    b.ToTable("BuildTaskFlowTasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BuildTaskFlowProjectId = 1,
                            BuildTaskFlowTaskStatusId = 4,
                            CompletedAt = new DateTime(2026, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Ana tablolar, ilişkiler ve seed verileri planlanacak.",
                            DueDate = new DateTime(2026, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Priority = "Yüksek",
                            Title = "Veritabanı tablolarını tasarlama"
                        },
                        new
                        {
                            Id = 2,
                            BuildTaskFlowProjectId = 1,
                            BuildTaskFlowTaskStatusId = 4,
                            CompletedAt = new DateTime(2026, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedAt = new DateTime(2026, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Şantiye/proje kaydı için model ve CRUD ekranları hazırlanacak.",
                            DueDate = new DateTime(2026, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Priority = "Yüksek",
                            Title = "ConstructionProject modelini oluşturma"
                        },
                        new
                        {
                            Id = 3,
                            BuildTaskFlowProjectId = 1,
                            BuildTaskFlowTaskStatusId = 2,
                            CreatedAt = new DateTime(2026, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Malzeme alımı yapıldığında stok miktarını artıran iş kuralı uygulanacak.",
                            DueDate = new DateTime(2026, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Priority = "Yüksek",
                            Title = "MaterialPurchase işlemini oluşturma"
                        },
                        new
                        {
                            Id = 4,
                            BuildTaskFlowProjectId = 1,
                            BuildTaskFlowTaskStatusId = 3,
                            CreatedAt = new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Toplam proje, gelir, gider ve net kar/zarar kartları kontrol edilecek.",
                            DueDate = new DateTime(2026, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Priority = "Orta",
                            Title = "Dashboard tasarımı"
                        },
                        new
                        {
                            Id = 5,
                            BuildTaskFlowProjectId = 2,
                            BuildTaskFlowTaskStatusId = 1,
                            CreatedAt = new DateTime(2026, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Yönetici, proje sorumlusu, şantiye şefi, malzeme sorumlusu ve muhasebe rollerinin giriş akışı hazırlanacak.",
                            DueDate = new DateTime(2026, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Priority = "Yüksek",
                            Title = "Rol ve giriş ekranı tasarımı"
                        },
                        new
                        {
                            Id = 6,
                            BuildTaskFlowProjectId = 2,
                            BuildTaskFlowTaskStatusId = 1,
                            CreatedAt = new DateTime(2026, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Tarihli, numaralı ve kalemli proforma/fatura taslağı ekranı hazırlanacak.",
                            DueDate = new DateTime(2026, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Priority = "Orta",
                            Title = "Proforma fatura taslağı ekranı"
                        });
                });

            modelBuilder.Entity("ConstructionManagementSystem.Models.BuildTaskFlowTaskAssignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AssignedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("BuildTaskFlowTaskId")
                        .HasColumnType("int");

                    b.Property<int>("BuildTaskFlowTeamMemberId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BuildTaskFlowTeamMemberId");

                    b.HasIndex("BuildTaskFlowTaskId", "BuildTaskFlowTeamMemberId")
                        .IsUnique();

                    b.ToTable("BuildTaskFlowTaskAssignments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AssignedAt = new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BuildTaskFlowTaskId = 1,
                            BuildTaskFlowTeamMemberId = 2
                        },
                        new
                        {
                            Id = 2,
                            AssignedAt = new DateTime(2026, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BuildTaskFlowTaskId = 2,
                            BuildTaskFlowTeamMemberId = 3
                        },
                        new
                        {
                            Id = 3,
                            AssignedAt = new DateTime(2026, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BuildTaskFlowTaskId = 3,
                            BuildTaskFlowTeamMemberId = 3
                        },
                        new
                        {
                            Id = 4,
                            AssignedAt = new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BuildTaskFlowTaskId = 4,
                            BuildTaskFlowTeamMemberId = 4
                        },
                        new
                        {
                            Id = 5,
                            AssignedAt = new DateTime(2026, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BuildTaskFlowTaskId = 5,
                            BuildTaskFlowTeamMemberId = 2
                        },
                        new
                        {
                            Id = 6,
                            AssignedAt = new DateTime(2026, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            BuildTaskFlowTaskId = 6,
                            BuildTaskFlowTeamMemberId = 5
                        });
                });

            modelBuilder.Entity("ConstructionManagementSystem.Models.BuildTaskFlowTaskStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BuildTaskFlowTaskStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Yapılacak",
                            SortOrder = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Devam Ediyor",
                            SortOrder = 2
                        },
                        new
                        {
                            Id = 3,
                            Name = "Test Ediliyor",
                            SortOrder = 3
                        },
                        new
                        {
                            Id = 4,
                            Name = "Tamamlandı",
                            SortOrder = 4
                        });
                });

            modelBuilder.Entity("ConstructionManagementSystem.Models.BuildTaskFlowTeamMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BuildTaskFlowRoleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(160)
                        .HasColumnType("nvarchar(160)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Phone")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("BuildTaskFlowRoleId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("BuildTaskFlowTeamMembers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BuildTaskFlowRoleId = 1,
                            CreatedAt = new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@buildtaskflow.local",
                            FullName = "Admin Kullanıcı",
                            IsActive = true,
                            PasswordHash = "8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92",
                            Phone = "0500 100 00 01"
                        },
                        new
                        {
                            Id = 2,
                            BuildTaskFlowRoleId = 2,
                            CreatedAt = new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "proje@buildtaskflow.local",
                            FullName = "Ece Proje",
                            IsActive = true,
                            PasswordHash = "8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92",
                            Phone = "0500 100 00 02"
                        },
                        new
                        {
                            Id = 3,
                            BuildTaskFlowRoleId = 3,
                            CreatedAt = new DateTime(2026, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "santiyesefi@buildtaskflow.local",
                            FullName = "Mert Şantiye Şefi",
                            IsActive = true,
                            PasswordHash = "8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92",
                            Phone = "0500 100 00 03"
                        },
                        new
                        {
                            Id = 4,
                            BuildTaskFlowRoleId = 4,
                            CreatedAt = new DateTime(2026, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "depo@buildtaskflow.local",
                            FullName = "Selin Depo Sorumlusu",
                            IsActive = true,
                            PasswordHash = "8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92",
                            Phone = "0500 100 00 04"
                        },
                        new
                        {
                            Id = 5,
                            BuildTaskFlowRoleId = 5,
                            CreatedAt = new DateTime(2026, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "muhasebe@buildtaskflow.local",
                            FullName = "Deniz Muhasebe",
                            IsActive = true,
                            PasswordHash = "8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92",
                            Phone = "0500 100 00 05"
                        });
                });

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

            modelBuilder.Entity("ConstructionManagementSystem.Models.BuildTaskFlowComment", b =>
                {
                    b.HasOne("ConstructionManagementSystem.Models.BuildTaskFlowTask", "Task")
                        .WithMany("Comments")
                        .HasForeignKey("BuildTaskFlowTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConstructionManagementSystem.Models.BuildTaskFlowTeamMember", "TeamMember")
                        .WithMany("Comments")
                        .HasForeignKey("BuildTaskFlowTeamMemberId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Task");

                    b.Navigation("TeamMember");
                });

            modelBuilder.Entity("ConstructionManagementSystem.Models.BuildTaskFlowInvoice", b =>
                {
                    b.HasOne("ConstructionManagementSystem.Models.BuildTaskFlowProject", "Project")
                        .WithMany("Invoices")
                        .HasForeignKey("BuildTaskFlowProjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ConstructionManagementSystem.Models.BuildTaskFlowInvoiceItem", b =>
                {
                    b.HasOne("ConstructionManagementSystem.Models.BuildTaskFlowInvoice", "Invoice")
                        .WithMany("Items")
                        .HasForeignKey("BuildTaskFlowInvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("ConstructionManagementSystem.Models.BuildTaskFlowProject", b =>
                {
                    b.HasOne("ConstructionManagementSystem.Models.BuildTaskFlowTeamMember", "OwnerTeamMember")
                        .WithMany("OwnedProjects")
                        .HasForeignKey("OwnerTeamMemberId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("OwnerTeamMember");
                });

            modelBuilder.Entity("ConstructionManagementSystem.Models.BuildTaskFlowTask", b =>
                {
                    b.HasOne("ConstructionManagementSystem.Models.BuildTaskFlowProject", "Project")
                        .WithMany("Tasks")
                        .HasForeignKey("BuildTaskFlowProjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ConstructionManagementSystem.Models.BuildTaskFlowTaskStatus", "Status")
                        .WithMany("Tasks")
                        .HasForeignKey("BuildTaskFlowTaskStatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("ConstructionManagementSystem.Models.BuildTaskFlowTaskAssignment", b =>
                {
                    b.HasOne("ConstructionManagementSystem.Models.BuildTaskFlowTask", "Task")
                        .WithMany("Assignments")
                        .HasForeignKey("BuildTaskFlowTaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConstructionManagementSystem.Models.BuildTaskFlowTeamMember", "TeamMember")
                        .WithMany("TaskAssignments")
                        .HasForeignKey("BuildTaskFlowTeamMemberId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Task");

                    b.Navigation("TeamMember");
                });

            modelBuilder.Entity("ConstructionManagementSystem.Models.BuildTaskFlowTeamMember", b =>
                {
                    b.HasOne("ConstructionManagementSystem.Models.BuildTaskFlowRole", "Role")
                        .WithMany("TeamMembers")
                        .HasForeignKey("BuildTaskFlowRoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");
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

            modelBuilder.Entity("ConstructionManagementSystem.Models.BuildTaskFlowInvoice", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("ConstructionManagementSystem.Models.BuildTaskFlowProject", b =>
                {
                    b.Navigation("Invoices");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("ConstructionManagementSystem.Models.BuildTaskFlowRole", b =>
                {
                    b.Navigation("TeamMembers");
                });

            modelBuilder.Entity("ConstructionManagementSystem.Models.BuildTaskFlowTask", b =>
                {
                    b.Navigation("Assignments");

                    b.Navigation("Comments");
                });

            modelBuilder.Entity("ConstructionManagementSystem.Models.BuildTaskFlowTaskStatus", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("ConstructionManagementSystem.Models.BuildTaskFlowTeamMember", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("OwnedProjects");

                    b.Navigation("TaskAssignments");
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
