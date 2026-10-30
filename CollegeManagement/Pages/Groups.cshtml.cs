using CollegeManagement.Data;
using CollegeManagement.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CollegeManagement.Pages;

public class GroupsModel(CollegeDbContext db) : PageModel
{
    public IReadOnlyCollection<Group> Groups { get; private set; } = Array.Empty<Group>();

    public async Task OnGetAsync() => Groups = await db.Groups.AsNoTracking().OrderBy(group => group.Name).ToListAsync();
}
