using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Pages.BuildTaskFlow.Tasks;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<BuildTaskFlowTask> Tasks { get; set; } = new List<BuildTaskFlowTask>();

    public async Task OnGetAsync()
    {
        Tasks = await _context.BuildTaskFlowTasks
            .Include(task => task.Project)
            .Include(task => task.Status)
            .Include(task => task.Assignments)
            .ThenInclude(assignment => assignment.TeamMember)
            .OrderBy(task => task.Status!.SortOrder)
            .ThenBy(task => task.DueDate ?? DateTime.MaxValue)
            .ToListAsync();
    }
}
