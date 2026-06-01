using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Pages.BuildTaskFlow.Projects;

public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DetailsModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public BuildTaskFlowProject Project { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var project = await _context.BuildTaskFlowProjects
            .Include(item => item.OwnerTeamMember)
            .Include(item => item.Tasks)
            .ThenInclude(task => task.Status)
            .Include(item => item.Tasks)
            .ThenInclude(task => task.Assignments)
            .ThenInclude(assignment => assignment.TeamMember)
            .Include(item => item.Invoices)
            .FirstOrDefaultAsync(item => item.Id == id);

        if (project is null)
        {
            return NotFound();
        }

        Project = project;
        return Page();
    }
}
