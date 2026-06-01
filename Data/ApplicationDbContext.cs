using ConstructionManagementSystem.Models;
using ConstructionManagementSystem.Services;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<ConstructionProject> ConstructionProjects => Set<ConstructionProject>();

    public DbSet<Client> Clients => Set<Client>();

    public DbSet<MaterialType> MaterialTypes => Set<MaterialType>();

    public DbSet<Material> Materials => Set<Material>();

    public DbSet<Supplier> Suppliers => Set<Supplier>();

    public DbSet<MaterialPurchase> MaterialPurchases => Set<MaterialPurchase>();

    public DbSet<Subcontractor> Subcontractors => Set<Subcontractor>();

    public DbSet<Worker> Workers => Set<Worker>();

    public DbSet<WorkerPayment> WorkerPayments => Set<WorkerPayment>();

    public DbSet<ProjectIncome> ProjectIncomes => Set<ProjectIncome>();

    public DbSet<Expense> Expenses => Set<Expense>();

    public DbSet<BuildTaskFlowRole> BuildTaskFlowRoles => Set<BuildTaskFlowRole>();

    public DbSet<BuildTaskFlowTeamMember> BuildTaskFlowTeamMembers => Set<BuildTaskFlowTeamMember>();

    public DbSet<BuildTaskFlowProject> BuildTaskFlowProjects => Set<BuildTaskFlowProject>();

    public DbSet<BuildTaskFlowTaskStatus> BuildTaskFlowTaskStatuses => Set<BuildTaskFlowTaskStatus>();

    public DbSet<BuildTaskFlowTask> BuildTaskFlowTasks => Set<BuildTaskFlowTask>();

    public DbSet<BuildTaskFlowTaskAssignment> BuildTaskFlowTaskAssignments => Set<BuildTaskFlowTaskAssignment>();

    public DbSet<BuildTaskFlowComment> BuildTaskFlowComments => Set<BuildTaskFlowComment>();

    public DbSet<BuildTaskFlowInvoice> BuildTaskFlowInvoices => Set<BuildTaskFlowInvoice>();

    public DbSet<BuildTaskFlowInvoiceItem> BuildTaskFlowInvoiceItems => Set<BuildTaskFlowInvoiceItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ConstructionProject>()
            .HasOne(project => project.Client)
            .WithMany(client => client.ConstructionProjects)
            .HasForeignKey(project => project.ClientId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Material>()
            .HasOne(material => material.MaterialType)
            .WithMany(type => type.Materials)
            .HasForeignKey(material => material.MaterialTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<MaterialPurchase>()
            .HasOne(purchase => purchase.ConstructionProject)
            .WithMany(project => project.MaterialPurchases)
            .HasForeignKey(purchase => purchase.ConstructionProjectId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<MaterialPurchase>()
            .HasOne(purchase => purchase.Material)
            .WithMany(material => material.MaterialPurchases)
            .HasForeignKey(purchase => purchase.MaterialId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<MaterialPurchase>()
            .HasOne(purchase => purchase.Supplier)
            .WithMany(supplier => supplier.MaterialPurchases)
            .HasForeignKey(purchase => purchase.SupplierId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<WorkerPayment>()
            .HasOne(payment => payment.Worker)
            .WithMany(worker => worker.WorkerPayments)
            .HasForeignKey(payment => payment.WorkerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<WorkerPayment>()
            .HasOne(payment => payment.ConstructionProject)
            .WithMany(project => project.WorkerPayments)
            .HasForeignKey(payment => payment.ConstructionProjectId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProjectIncome>()
            .HasOne(income => income.ConstructionProject)
            .WithMany(project => project.ProjectIncomes)
            .HasForeignKey(income => income.ConstructionProjectId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Expense>()
            .HasOne(expense => expense.ConstructionProject)
            .WithMany(project => project.Expenses)
            .HasForeignKey(expense => expense.ConstructionProjectId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<BuildTaskFlowRole>()
            .HasIndex(role => role.Name)
            .IsUnique();

        modelBuilder.Entity<BuildTaskFlowTeamMember>()
            .HasIndex(member => member.Email)
            .IsUnique();

        modelBuilder.Entity<BuildTaskFlowTeamMember>()
            .HasOne(member => member.Role)
            .WithMany(role => role.TeamMembers)
            .HasForeignKey(member => member.BuildTaskFlowRoleId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<BuildTaskFlowProject>()
            .HasOne(project => project.OwnerTeamMember)
            .WithMany(member => member.OwnedProjects)
            .HasForeignKey(project => project.OwnerTeamMemberId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<BuildTaskFlowTask>()
            .HasOne(task => task.Project)
            .WithMany(project => project.Tasks)
            .HasForeignKey(task => task.BuildTaskFlowProjectId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<BuildTaskFlowTask>()
            .HasOne(task => task.Status)
            .WithMany(status => status.Tasks)
            .HasForeignKey(task => task.BuildTaskFlowTaskStatusId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<BuildTaskFlowTaskAssignment>()
            .HasIndex(assignment => new { assignment.BuildTaskFlowTaskId, assignment.BuildTaskFlowTeamMemberId })
            .IsUnique();

        modelBuilder.Entity<BuildTaskFlowTaskAssignment>()
            .HasOne(assignment => assignment.Task)
            .WithMany(task => task.Assignments)
            .HasForeignKey(assignment => assignment.BuildTaskFlowTaskId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BuildTaskFlowTaskAssignment>()
            .HasOne(assignment => assignment.TeamMember)
            .WithMany(member => member.TaskAssignments)
            .HasForeignKey(assignment => assignment.BuildTaskFlowTeamMemberId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<BuildTaskFlowComment>()
            .HasOne(comment => comment.Task)
            .WithMany(task => task.Comments)
            .HasForeignKey(comment => comment.BuildTaskFlowTaskId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BuildTaskFlowComment>()
            .HasOne(comment => comment.TeamMember)
            .WithMany(member => member.Comments)
            .HasForeignKey(comment => comment.BuildTaskFlowTeamMemberId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<BuildTaskFlowInvoice>()
            .HasOne(invoice => invoice.Project)
            .WithMany(project => project.Invoices)
            .HasForeignKey(invoice => invoice.BuildTaskFlowProjectId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<BuildTaskFlowInvoice>()
            .HasIndex(invoice => invoice.InvoiceNumber)
            .IsUnique();

        modelBuilder.Entity<BuildTaskFlowInvoice>()
            .Property(invoice => invoice.SubTotal)
            .HasPrecision(18, 2);

        modelBuilder.Entity<BuildTaskFlowInvoice>()
            .Property(invoice => invoice.TaxRate)
            .HasPrecision(5, 2);

        modelBuilder.Entity<BuildTaskFlowInvoice>()
            .Property(invoice => invoice.TaxAmount)
            .HasPrecision(18, 2);

        modelBuilder.Entity<BuildTaskFlowInvoice>()
            .Property(invoice => invoice.GrandTotal)
            .HasPrecision(18, 2);

        modelBuilder.Entity<BuildTaskFlowInvoiceItem>()
            .HasOne(item => item.Invoice)
            .WithMany(invoice => invoice.Items)
            .HasForeignKey(item => item.BuildTaskFlowInvoiceId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BuildTaskFlowInvoiceItem>()
            .Property(item => item.Quantity)
            .HasPrecision(18, 2);

        modelBuilder.Entity<BuildTaskFlowInvoiceItem>()
            .Property(item => item.UnitPrice)
            .HasPrecision(18, 2);

        modelBuilder.Entity<BuildTaskFlowInvoiceItem>()
            .Property(item => item.LineTotal)
            .HasPrecision(18, 2);

        modelBuilder.Entity<MaterialType>().HasData(
            new MaterialType { Id = 1, Name = "Beton" },
            new MaterialType { Id = 2, Name = "Demir" },
            new MaterialType { Id = 3, Name = "Tuğla" },
            new MaterialType { Id = 4, Name = "Kalıp" },
            new MaterialType { Id = 5, Name = "Çimento" },
            new MaterialType { Id = 6, Name = "Elektrik Malzemesi" },
            new MaterialType { Id = 7, Name = "Sıhhi Tesisat Malzemesi" });

        modelBuilder.Entity<Client>().HasData(
            new Client { Id = 1, FullName = "Mehmet Yılmaz", CompanyName = "Yılmaz Apartman Yönetimi", Phone = "0532 111 22 33", Address = "İstanbul / Kadıköy" },
            new Client { Id = 2, FullName = "Ayşe Demir", CompanyName = "Demir Gayrimenkul A.Ş.", Phone = "0541 222 33 44", Address = "Ankara / Çankaya" },
            new Client { Id = 3, FullName = "Hasan Kaya", CompanyName = "Kaya Lojistik Ltd.", Phone = "0555 333 44 55", Address = "Bursa / Nilüfer" });

        modelBuilder.Entity<Supplier>().HasData(
            new Supplier { Id = 1, CompanyName = "Marmara Beton Sanayi", ContactName = "Ali Betoncu", Phone = "0216 444 10 10", Address = "İstanbul / Tuzla" },
            new Supplier { Id = 2, CompanyName = "Anadolu Demir Çelik", ContactName = "Fatma Çelik", Phone = "0312 555 20 20", Address = "Ankara / Sincan" },
            new Supplier { Id = 3, CompanyName = "Güven Yapı Market", ContactName = "Mustafa Şahin", Phone = "0224 666 30 30", Address = "Bursa / Osmangazi" },
            new Supplier { Id = 4, CompanyName = "Eksen Elektrik Malzemeleri", ContactName = "Zeynep Aksoy", Phone = "0212 777 40 40", Address = "İstanbul / Bayrampaşa" });

        modelBuilder.Entity<Subcontractor>().HasData(
            new Subcontractor { Id = 1, CompanyName = "Usta Demir Donatı", WorkType = "Demirci", ContactName = "Kemal Usta", Phone = "0533 410 20 10", Address = "İstanbul / Pendik" },
            new Subcontractor { Id = 2, CompanyName = "Sağlam Kalıp Sistemleri", WorkType = "Kalıpçı", ContactName = "Murat Sağlam", Phone = "0534 420 20 10", Address = "İstanbul / Kartal" },
            new Subcontractor { Id = 3, CompanyName = "Parlak Elektrik Taahhüt", WorkType = "Elektrik", ContactName = "Emre Parlak", Phone = "0535 430 20 10", Address = "Ankara / Yenimahalle" },
            new Subcontractor { Id = 4, CompanyName = "Akış Tesisat", WorkType = "Sıhhi Tesisat", ContactName = "Selim Akış", Phone = "0536 440 20 10", Address = "Bursa / Nilüfer" });

        modelBuilder.Entity<Worker>().HasData(
            new Worker { Id = 1, FullName = "Ahmet Usta", Phone = "0532 500 10 10", JobTitle = "Usta", DailyWage = 1800m, IsActive = true },
            new Worker { Id = 2, FullName = "Mehmet Kalfa", Phone = "0532 500 10 11", JobTitle = "Kalfa", DailyWage = 1400m, IsActive = true },
            new Worker { Id = 3, FullName = "Hasan İşçi", Phone = "0532 500 10 12", JobTitle = "İnşaat işçisi", DailyWage = 1100m, IsActive = true },
            new Worker { Id = 4, FullName = "Ali Elektrikçi", Phone = "0532 500 10 13", JobTitle = "Elektrik ustası", DailyWage = 1700m, IsActive = true },
            new Worker { Id = 5, FullName = "Serkan Tesisatçı", Phone = "0532 500 10 14", JobTitle = "Tesisat ustası", DailyWage = 1650m, IsActive = true });

        modelBuilder.Entity<ConstructionProject>().HasData(
            new ConstructionProject
            {
                Id = 1,
                Name = "Kadıköy Konut Şantiyesi",
                ClientId = 1,
                Location = "İstanbul / Kadıköy",
                StartDate = new DateTime(2026, 1, 15),
                EndDate = null,
                Status = "Aktif",
                ContractAmount = 8500000m,
                Description = "12 daireli konut inşaatı ve çevre düzenleme işi."
            },
            new ConstructionProject
            {
                Id = 2,
                Name = "Nilüfer Depo Güçlendirme",
                ClientId = 3,
                Location = "Bursa / Nilüfer",
                StartDate = new DateTime(2025, 9, 1),
                EndDate = new DateTime(2026, 3, 30),
                Status = "Tamamlandı",
                ContractAmount = 4250000m,
                Description = "Mevcut depo binası güçlendirme ve tesisat yenileme işi."
            });

        modelBuilder.Entity<Material>().HasData(
            new Material { Id = 1, Name = "C30 Hazır Beton", MaterialTypeId = 1, Unit = "m³", UnitPrice = 2450m, StockQuantity = 120m, Description = "Temel ve kolon betonlarında kullanılır." },
            new Material { Id = 2, Name = "12'lik İnşaat Demiri", MaterialTypeId = 2, Unit = "ton", UnitPrice = 26500m, StockQuantity = 15m, Description = "Taşıyıcı donatı demiri." },
            new Material { Id = 3, Name = "8'lik İnşaat Demiri", MaterialTypeId = 2, Unit = "ton", UnitPrice = 25500m, StockQuantity = 0m, Description = "Etriye ve yardımcı donatı işleri." },
            new Material { Id = 4, Name = "Tuğla", MaterialTypeId = 3, Unit = "adet", UnitPrice = 8m, StockQuantity = 0m, Description = "Duvar imalatı için standart tuğla." },
            new Material { Id = 5, Name = "Çimento", MaterialTypeId = 5, Unit = "torba", UnitPrice = 185m, StockQuantity = 500m, Description = "Sıva, şap ve küçük beton işleri." },
            new Material { Id = 6, Name = "Kalıp Tahtası", MaterialTypeId = 4, Unit = "adet", UnitPrice = 320m, StockQuantity = 0m, Description = "Kalıp kurulumlarında kullanılır." },
            new Material { Id = 7, Name = "Elektrik Kablosu", MaterialTypeId = 6, Unit = "metre", UnitPrice = 42m, StockQuantity = 0m, Description = "İç tesisat elektrik kablosu." },
            new Material { Id = 8, Name = "PVC Boru", MaterialTypeId = 7, Unit = "metre", UnitPrice = 65m, StockQuantity = 0m, Description = "Temiz ve pis su tesisatı için PVC boru." });

        modelBuilder.Entity<MaterialPurchase>().HasData(
            new MaterialPurchase { Id = 1, ConstructionProjectId = 1, MaterialId = 1, SupplierId = 1, PurchaseDate = new DateTime(2026, 2, 5), Quantity = 120m, UnitPrice = 2450m, TotalAmount = 294000m, Description = "Temel betonu için ilk sevkiyat." },
            new MaterialPurchase { Id = 2, ConstructionProjectId = 1, MaterialId = 2, SupplierId = 2, PurchaseDate = new DateTime(2026, 2, 12), Quantity = 15m, UnitPrice = 26500m, TotalAmount = 397500m, Description = "Radye temel ve kolon donatısı." },
            new MaterialPurchase { Id = 3, ConstructionProjectId = 2, MaterialId = 5, SupplierId = 3, PurchaseDate = new DateTime(2026, 1, 18), Quantity = 500m, UnitPrice = 185m, TotalAmount = 92500m, Description = "Güçlendirme sıva ve şap işleri." });

        modelBuilder.Entity<WorkerPayment>().HasData(
            new WorkerPayment { Id = 1, WorkerId = 1, ConstructionProjectId = 1, PaymentDate = new DateTime(2026, 3, 1), WorkDays = 12, Amount = 21600m, Description = "Şubat ayı kaba inşaat ustalık ödemesi." },
            new WorkerPayment { Id = 2, WorkerId = 3, ConstructionProjectId = 1, PaymentDate = new DateTime(2026, 3, 1), WorkDays = 15, Amount = 16500m, Description = "Şubat ayı yardımcı işçi ödemesi." },
            new WorkerPayment { Id = 3, WorkerId = 4, ConstructionProjectId = 2, PaymentDate = new DateTime(2026, 2, 20), WorkDays = 8, Amount = 13600m, Description = "Depo elektrik tesisatı yenileme ödemesi." });

        modelBuilder.Entity<ProjectIncome>().HasData(
            new ProjectIncome { Id = 1, ConstructionProjectId = 1, IncomeDate = new DateTime(2026, 2, 28), Amount = 1250000m, Description = "Birinci hakediş tahsilatı." },
            new ProjectIncome { Id = 2, ConstructionProjectId = 1, IncomeDate = new DateTime(2026, 4, 15), Amount = 1750000m, Description = "İkinci hakediş tahsilatı." },
            new ProjectIncome { Id = 3, ConstructionProjectId = 2, IncomeDate = new DateTime(2026, 3, 30), Amount = 4250000m, Description = "Proje kapanış tahsilatı." });

        modelBuilder.Entity<Expense>().HasData(
            new Expense { Id = 1, ConstructionProjectId = 1, Title = "Şantiye yemek gideri", Category = "Yemek", Amount = 18500m, ExpenseDate = new DateTime(2026, 3, 5), Description = "Şubat ayı personel yemek gideri." },
            new Expense { Id = 2, ConstructionProjectId = 1, Title = "Beton pompası nakliye", Category = "Nakliye", Amount = 9500m, ExpenseDate = new DateTime(2026, 2, 5), Description = "Beton dökümü için pompa ve nakliye hizmeti." },
            new Expense { Id = 3, ConstructionProjectId = 1, Title = "Jeneratör yakıtı", Category = "Yakıt", Amount = 7200m, ExpenseDate = new DateTime(2026, 3, 12), Description = "Şantiye jeneratörü mazot alımı." },
            new Expense { Id = 4, ConstructionProjectId = 2, Title = "Şantiye elektrik faturası", Category = "Elektrik", Amount = 4300m, ExpenseDate = new DateTime(2026, 2, 25), Description = "Depo güçlendirme elektrik tüketimi." },
            new Expense { Id = 5, ConstructionProjectId = 2, Title = "Kompresör bakım gideri", Category = "Bakım", Amount = 6200m, ExpenseDate = new DateTime(2026, 1, 28), Description = "Saha ekipmanı bakım işlemi." });

        modelBuilder.Entity<BuildTaskFlowRole>().HasData(
            new BuildTaskFlowRole { Id = 1, Name = BuildTaskFlowRoleNames.Admin, Description = "Sistemdeki tüm proje yönetimi işlemlerini yapabilir." },
            new BuildTaskFlowRole { Id = 2, Name = BuildTaskFlowRoleNames.ProjectManager, Description = "Proje ve görev planını yönetir." },
            new BuildTaskFlowRole { Id = 3, Name = BuildTaskFlowRoleNames.SiteChief, Description = "Şantiye projelerini, işçileri ve saha görevlerini takip eder." },
            new BuildTaskFlowRole { Id = 4, Name = BuildTaskFlowRoleNames.MaterialManager, Description = "Malzemeleri, tedarikçileri, stokları ve malzeme alımlarını yönetir." },
            new BuildTaskFlowRole { Id = 5, Name = BuildTaskFlowRoleNames.Accounting, Description = "Proforma/fatura taslaklarını ve ödeme planını takip eder." },
            new BuildTaskFlowRole { Id = 6, Name = BuildTaskFlowRoleNames.Viewer, Description = "Sistemi sadece görüntüler." });

        var samplePasswordHash = BuildTaskFlowPasswordHasher.HashPassword("123456");

        modelBuilder.Entity<BuildTaskFlowTeamMember>().HasData(
            new BuildTaskFlowTeamMember { Id = 1, FullName = "Admin Kullanıcı", Email = "admin@buildtaskflow.local", Phone = "0500 100 00 01", PasswordHash = samplePasswordHash, BuildTaskFlowRoleId = 1, IsActive = true, CreatedAt = new DateTime(2026, 5, 1) },
            new BuildTaskFlowTeamMember { Id = 2, FullName = "Ece Proje", Email = "proje@buildtaskflow.local", Phone = "0500 100 00 02", PasswordHash = samplePasswordHash, BuildTaskFlowRoleId = 2, IsActive = true, CreatedAt = new DateTime(2026, 5, 1) },
            new BuildTaskFlowTeamMember { Id = 3, FullName = "Mert Şantiye Şefi", Email = "santiyesefi@buildtaskflow.local", Phone = "0500 100 00 03", PasswordHash = samplePasswordHash, BuildTaskFlowRoleId = 3, IsActive = true, CreatedAt = new DateTime(2026, 5, 2) },
            new BuildTaskFlowTeamMember { Id = 4, FullName = "Selin Depo Sorumlusu", Email = "depo@buildtaskflow.local", Phone = "0500 100 00 04", PasswordHash = samplePasswordHash, BuildTaskFlowRoleId = 4, IsActive = true, CreatedAt = new DateTime(2026, 5, 2) },
            new BuildTaskFlowTeamMember { Id = 5, FullName = "Deniz Muhasebe", Email = "muhasebe@buildtaskflow.local", Phone = "0500 100 00 05", PasswordHash = samplePasswordHash, BuildTaskFlowRoleId = 5, IsActive = true, CreatedAt = new DateTime(2026, 5, 3) },
            new BuildTaskFlowTeamMember { Id = 6, FullName = "Can Görüntüleyici", Email = "goruntuleyici@buildtaskflow.local", Phone = "0500 100 00 06", PasswordHash = samplePasswordHash, BuildTaskFlowRoleId = 6, IsActive = true, CreatedAt = new DateTime(2026, 5, 3) });

        modelBuilder.Entity<BuildTaskFlowTaskStatus>().HasData(
            new BuildTaskFlowTaskStatus { Id = 1, Name = "Yapılacak", SortOrder = 1 },
            new BuildTaskFlowTaskStatus { Id = 2, Name = "Devam Ediyor", SortOrder = 2 },
            new BuildTaskFlowTaskStatus { Id = 3, Name = "Test Ediliyor", SortOrder = 3 },
            new BuildTaskFlowTaskStatus { Id = 4, Name = "Tamamlandı", SortOrder = 4 });

        modelBuilder.Entity<BuildTaskFlowProject>().HasData(
            new BuildTaskFlowProject
            {
                Id = 1,
                Name = "İnşaat Otomasyonu Geliştirme Projesi",
                Description = "Şantiye, malzeme, işçi, gelir ve gider ekranlarının geliştirme planı.",
                StartDate = new DateTime(2026, 5, 1),
                EndDate = new DateTime(2026, 6, 10),
                Status = "Devam Ediyor",
                OwnerTeamMemberId = 2
            },
            new BuildTaskFlowProject
            {
                Id = 2,
                Name = "Şantiye Görev Takip Kurulumu",
                Description = "Saha ekiplerinin görev, durum ve teslim tarihlerini takip etmesi için proje yönetimi kurulumu.",
                StartDate = new DateTime(2026, 5, 15),
                EndDate = new DateTime(2026, 6, 25),
                Status = "Planlandı",
                OwnerTeamMemberId = 2
            });

        modelBuilder.Entity<BuildTaskFlowTask>().HasData(
            new BuildTaskFlowTask { Id = 1, BuildTaskFlowProjectId = 1, BuildTaskFlowTaskStatusId = 4, Title = "Veritabanı tablolarını tasarlama", Description = "Ana tablolar, ilişkiler ve seed verileri planlanacak.", Priority = "Yüksek", DueDate = new DateTime(2026, 5, 8), CreatedAt = new DateTime(2026, 5, 1), CompletedAt = new DateTime(2026, 5, 7) },
            new BuildTaskFlowTask { Id = 2, BuildTaskFlowProjectId = 1, BuildTaskFlowTaskStatusId = 4, Title = "ConstructionProject modelini oluşturma", Description = "Şantiye/proje kaydı için model ve CRUD ekranları hazırlanacak.", Priority = "Yüksek", DueDate = new DateTime(2026, 5, 10), CreatedAt = new DateTime(2026, 5, 2), CompletedAt = new DateTime(2026, 5, 10) },
            new BuildTaskFlowTask { Id = 3, BuildTaskFlowProjectId = 1, BuildTaskFlowTaskStatusId = 2, Title = "MaterialPurchase işlemini oluşturma", Description = "Malzeme alımı yapıldığında stok miktarını artıran iş kuralı uygulanacak.", Priority = "Yüksek", DueDate = new DateTime(2026, 5, 24), CreatedAt = new DateTime(2026, 5, 12) },
            new BuildTaskFlowTask { Id = 4, BuildTaskFlowProjectId = 1, BuildTaskFlowTaskStatusId = 3, Title = "Dashboard tasarımı", Description = "Toplam proje, gelir, gider ve net kar/zarar kartları kontrol edilecek.", Priority = "Orta", DueDate = new DateTime(2026, 5, 26), CreatedAt = new DateTime(2026, 5, 14) },
            new BuildTaskFlowTask { Id = 5, BuildTaskFlowProjectId = 2, BuildTaskFlowTaskStatusId = 1, Title = "Rol ve giriş ekranı tasarımı", Description = "Yönetici, proje sorumlusu, şantiye şefi, malzeme sorumlusu ve muhasebe rollerinin giriş akışı hazırlanacak.", Priority = "Yüksek", DueDate = new DateTime(2026, 6, 3), CreatedAt = new DateTime(2026, 5, 16) },
            new BuildTaskFlowTask { Id = 6, BuildTaskFlowProjectId = 2, BuildTaskFlowTaskStatusId = 1, Title = "Proforma fatura taslağı ekranı", Description = "Tarihli, numaralı ve kalemli proforma/fatura taslağı ekranı hazırlanacak.", Priority = "Orta", DueDate = new DateTime(2026, 6, 8), CreatedAt = new DateTime(2026, 5, 17) });

        modelBuilder.Entity<BuildTaskFlowTaskAssignment>().HasData(
            new BuildTaskFlowTaskAssignment { Id = 1, BuildTaskFlowTaskId = 1, BuildTaskFlowTeamMemberId = 2, AssignedAt = new DateTime(2026, 5, 1) },
            new BuildTaskFlowTaskAssignment { Id = 2, BuildTaskFlowTaskId = 2, BuildTaskFlowTeamMemberId = 3, AssignedAt = new DateTime(2026, 5, 2) },
            new BuildTaskFlowTaskAssignment { Id = 3, BuildTaskFlowTaskId = 3, BuildTaskFlowTeamMemberId = 3, AssignedAt = new DateTime(2026, 5, 12) },
            new BuildTaskFlowTaskAssignment { Id = 4, BuildTaskFlowTaskId = 4, BuildTaskFlowTeamMemberId = 4, AssignedAt = new DateTime(2026, 5, 14) },
            new BuildTaskFlowTaskAssignment { Id = 5, BuildTaskFlowTaskId = 5, BuildTaskFlowTeamMemberId = 2, AssignedAt = new DateTime(2026, 5, 16) },
            new BuildTaskFlowTaskAssignment { Id = 6, BuildTaskFlowTaskId = 6, BuildTaskFlowTeamMemberId = 5, AssignedAt = new DateTime(2026, 5, 17) });

        modelBuilder.Entity<BuildTaskFlowComment>().HasData(
            new BuildTaskFlowComment { Id = 1, BuildTaskFlowTaskId = 3, BuildTaskFlowTeamMemberId = 2, Text = "Stok artışı iş kuralı süreç takibinde özellikle kontrol edilecek.", CreatedAt = new DateTime(2026, 5, 20, 10, 30, 0) },
            new BuildTaskFlowComment { Id = 2, BuildTaskFlowTaskId = 4, BuildTaskFlowTeamMemberId = 4, Text = "Dashboard kartları test edildi, tarih ve para gösterimleri kontrol edilecek.", CreatedAt = new DateTime(2026, 5, 22, 14, 15, 0) });

        modelBuilder.Entity<BuildTaskFlowInvoice>().HasData(
            new BuildTaskFlowInvoice
            {
                Id = 1,
                InvoiceNumber = "PRF-2026-001",
                BuildTaskFlowProjectId = 1,
                CustomerTitle = "Yılmaz Apartman Yönetimi",
                InvoiceDate = new DateTime(2026, 5, 20),
                DueDate = new DateTime(2026, 6, 4),
                Status = "Taslak",
                SubTotal = 150000m,
                TaxRate = 20m,
                TaxAmount = 30000m,
                GrandTotal = 180000m,
                Notes = "Bu kayıt resmi fatura değil, operasyon takibi için hazırlanmış proforma/fatura taslağıdır."
            });

        modelBuilder.Entity<BuildTaskFlowInvoiceItem>().HasData(
            new BuildTaskFlowInvoiceItem { Id = 1, BuildTaskFlowInvoiceId = 1, Description = "Şantiye yönetim sistemi geliştirme hizmeti", Quantity = 1m, UnitPrice = 150000m, LineTotal = 150000m });
    }
}

