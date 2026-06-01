using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Pages.BuildTaskFlow.Projects;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<BuildTaskFlowProject> Projects { get; set; } = new List<BuildTaskFlowProject>();

    public async Task OnGetAsync()
    {
        Projects = await _context.BuildTaskFlowProjects
            .Include(project => project.OwnerTeamMember)
            .Include(project => project.Tasks)
            .ThenInclude(task => task.Status)
            .OrderBy(project => project.EndDate ?? DateTime.MaxValue)
            .ToListAsync();
    }
}
