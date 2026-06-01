using ConstructionManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ConstructionManagementSystem.Pages.SqlQueries;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public string SqlQuery { get; set; } = DefaultQuery;

    public List<string> Columns { get; set; } = new();

    public List<List<string>> Rows { get; set; } = new();

    public string? ErrorMessage { get; set; }

    public string? SuccessMessage { get; set; }

    public IReadOnlyList<SqlSample> Samples { get; } =
    [
        new("projects", "Tüm projeler", "SELECT Id, Name, Location, Status, ContractAmount FROM ConstructionProjects ORDER BY StartDate DESC"),
        new("active-projects", "Aktif projeler", "SELECT Id, Name, Location, ContractAmount FROM ConstructionProjects WHERE Status = N'Aktif' ORDER BY Name"),
        new("materials", "Malzemeler ve stok", "SELECT Name, Unit, UnitPrice, StockQuantity FROM Materials ORDER BY StockQuantity DESC"),
        new("project-materials", "Projeye göre malzeme alımları", """
            SELECT cp.Name AS ProjectName, m.Name AS MaterialName, s.CompanyName AS SupplierName, mp.Quantity, mp.UnitPrice, mp.TotalAmount
            FROM MaterialPurchases mp
            JOIN ConstructionProjects cp ON mp.ConstructionProjectId = cp.Id
            JOIN Materials m ON mp.MaterialId = m.Id
            JOIN Suppliers s ON mp.SupplierId = s.Id
            ORDER BY mp.PurchaseDate DESC
            """),
        new("worker-payments", "Projeye göre işçi ödemeleri", """
            SELECT cp.Name AS ProjectName, w.FullName AS WorkerName, wp.WorkDays, wp.Amount, wp.PaymentDate
            FROM WorkerPayments wp
            JOIN ConstructionProjects cp ON wp.ConstructionProjectId = cp.Id
            JOIN Workers w ON wp.WorkerId = w.Id
            ORDER BY wp.PaymentDate DESC
            """),
        new("expenses", "Projeye göre giderler", """
            SELECT cp.Name AS ProjectName, e.Title, e.Category, e.Amount, e.ExpenseDate
            FROM Expenses e
            JOIN ConstructionProjects cp ON e.ConstructionProjectId = cp.Id
            ORDER BY e.ExpenseDate DESC
            """),
        new("supplier-total", "Tedarikçiye göre toplam alım", """
            SELECT s.CompanyName, SUM(mp.TotalAmount) AS TotalPurchaseAmount
            FROM MaterialPurchases mp
            JOIN Suppliers s ON mp.SupplierId = s.Id
            GROUP BY s.CompanyName
            ORDER BY TotalPurchaseAmount DESC
            """),
        new("material-type-stock", "Malzeme türüne göre stok", """
            SELECT mt.Name AS MaterialType, SUM(m.StockQuantity) AS TotalStock
            FROM Materials m
            JOIN MaterialTypes mt ON m.MaterialTypeId = mt.Id
            GROUP BY mt.Name
            ORDER BY mt.Name
            """),
        new("dashboard", "Dashboard toplamları", """
            SELECT
                (SELECT COUNT(*) FROM ConstructionProjects) AS TotalProjects,
                (SELECT COUNT(*) FROM ConstructionProjects WHERE Status = N'Aktif') AS ActiveProjects,
                (SELECT ISNULL(SUM(ContractAmount), 0) FROM ConstructionProjects) AS TotalContractAmount,
                (SELECT ISNULL(SUM(Amount), 0) FROM ProjectIncomes) AS TotalProjectIncome,
                (SELECT ISNULL(SUM(TotalAmount), 0) FROM MaterialPurchases) AS TotalMaterialPurchaseCost,
                (SELECT ISNULL(SUM(Amount), 0) FROM WorkerPayments) AS TotalWorkerPayment,
                (SELECT ISNULL(SUM(Amount), 0) FROM Expenses) AS TotalExpense
            """),
        new("net-profit", "Net kar/zarar", """
            SELECT
                (SELECT ISNULL(SUM(Amount), 0) FROM ProjectIncomes)
                - (SELECT ISNULL(SUM(TotalAmount), 0) FROM MaterialPurchases)
                - (SELECT ISNULL(SUM(Amount), 0) FROM WorkerPayments)
                - (SELECT ISNULL(SUM(Amount), 0) FROM Expenses) AS NetProfitOrLoss
            """)
    ];

    private const string DefaultQuery = "SELECT Id, Name, Location, Status, ContractAmount FROM ConstructionProjects ORDER BY StartDate DESC";

    public IActionResult OnGet(string? sample)
    {
        var selectedSample = Samples.FirstOrDefault(item => item.Key == sample);
        if (selectedSample is not null)
        {
            SqlQuery = selectedSample.Query;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var normalizedQuery = NormalizeQuery(SqlQuery);
        if (!IsReadOnlySelect(normalizedQuery))
        {
            ErrorMessage = "Bu ekranda sadece tek bir SELECT sorgusu çalıştırılabilir. INSERT, UPDATE, DELETE, DROP gibi komutlara izin verilmez.";
            return Page();
        }

        try
        {
            await ExecuteQueryAsync(normalizedQuery);
            SuccessMessage = $"{Rows.Count} satır listelendi.";
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
        }

        return Page();
    }

    private async Task ExecuteQueryAsync(string query)
    {
        await using var connection = _context.Database.GetDbConnection();
        if (connection.State != ConnectionState.Open)
        {
            await connection.OpenAsync();
        }

        await using var command = connection.CreateCommand();
        command.CommandText = query;
        command.CommandType = CommandType.Text;
        command.CommandTimeout = 30;

        await using var reader = await command.ExecuteReaderAsync();

        Columns = Enumerable.Range(0, reader.FieldCount)
            .Select(reader.GetName)
            .ToList();

        const int maxRows = 200;
        while (await reader.ReadAsync() && Rows.Count < maxRows)
        {
            var values = new List<string>();
            for (var i = 0; i < reader.FieldCount; i++)
            {
                values.Add(FormatValue(reader.GetValue(i)));
            }

            Rows.Add(values);
        }
    }

    private static string NormalizeQuery(string query)
    {
        var normalizedQuery = query.Trim();
        if (normalizedQuery.EndsWith(';'))
        {
            normalizedQuery = normalizedQuery[..^1].Trim();
        }

        return normalizedQuery;
    }

    private static bool IsReadOnlySelect(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return false;
        }

        if (query.Contains(';'))
        {
            return false;
        }

        if (!Regex.IsMatch(query, @"^\s*(SELECT|WITH)\b", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
        {
            return false;
        }

        return !Regex.IsMatch(
            query,
            @"\b(INSERT|UPDATE|DELETE|DROP|ALTER|CREATE|TRUNCATE|MERGE|EXEC|EXECUTE|GRANT|REVOKE|BACKUP|RESTORE|DBCC|USE)\b",
            RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
    }

    private static string FormatValue(object value)
    {
        return value switch
        {
            DBNull => string.Empty,
            DateTime dateTime => dateTime.ToString("dd.MM.yyyy HH:mm", CultureInfo.CurrentCulture),
            decimal decimalValue => decimalValue.ToString("N2", CultureInfo.CurrentCulture),
            byte[] => "[binary]",
            IFormattable formattable => formattable.ToString(null, CultureInfo.CurrentCulture),
            _ => value.ToString() ?? string.Empty
        };
    }
}

public record SqlSample(string Key, string Title, string Query);
