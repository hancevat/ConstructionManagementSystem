using ConstructionManagementSystem.Data;
using ConstructionManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConstructionManagementSystem.Pages.ConstructionProjects;

public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DetailsModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public ConstructionProject ConstructionProject { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var project = await _context.ConstructionProjects
            .Include(item => item.Client)
            .FirstOrDefaultAsync(item => item.Id == id);

        if (project is null)
        {
            return NotFound();
        }

        ConstructionProject = project;

        return Page();
    }
}

