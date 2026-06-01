using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Pages;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public int TotalProjects { get; set; }

    public int ActiveProjects { get; set; }

    public decimal TotalContractAmount { get; set; }

    public decimal TotalProjectIncome { get; set; }

    public decimal TotalMaterialPurchaseCost { get; set; }

    public decimal TotalWorkerPayment { get; set; }

    public decimal TotalExpense { get; set; }

    public decimal NetProfit => TotalProjectIncome - TotalMaterialPurchaseCost - TotalWorkerPayment - TotalExpense;

    public IList<ConstructionProject> RecentProjects { get; set; } = new List<ConstructionProject>();

    public async Task OnGetAsync()
    {
        TotalProjects = await _context.ConstructionProjects.CountAsync();
        ActiveProjects = await _context.ConstructionProjects.CountAsync(project => project.Status == "Aktif");
        TotalContractAmount = await _context.ConstructionProjects.SumAsync(project => (decimal?)project.ContractAmount) ?? 0;
        TotalProjectIncome = await _context.ProjectIncomes.SumAsync(income => (decimal?)income.Amount) ?? 0;
        TotalMaterialPurchaseCost = await _context.MaterialPurchases.SumAsync(purchase => (decimal?)purchase.TotalAmount) ?? 0;
        TotalWorkerPayment = await _context.WorkerPayments.SumAsync(payment => (decimal?)payment.Amount) ?? 0;
        TotalExpense = await _context.Expenses.SumAsync(expense => (decimal?)expense.Amount) ?? 0;

        RecentProjects = await _context.ConstructionProjects
            .Include(project => project.Client)
            .OrderByDescending(project => project.StartDate)
            .Take(5)
            .ToListAsync();
    }
}

