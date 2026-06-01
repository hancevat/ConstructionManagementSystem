using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Pages.BuildTaskFlow.TeamMembers;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<BuildTaskFlowTeamMember> TeamMembers { get; set; } = new List<BuildTaskFlowTeamMember>();

    public async Task OnGetAsync()
    {
        TeamMembers = await _context.BuildTaskFlowTeamMembers
            .Include(member => member.Role)
            .Include(member => member.TaskAssignments)
            .OrderBy(member => member.FullName)
            .ToListAsync();
    }
}
