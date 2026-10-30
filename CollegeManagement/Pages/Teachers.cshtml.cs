using CollegeManagement.Data;
using CollegeManagement.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CollegeManagement.Pages;

public class TeachersModel(CollegeDbContext db) : PageModel
{
    public IReadOnlyCollection<Teacher> Teachers { get; private set; } = Array.Empty<Teacher>();

    public async Task OnGetAsync() => Teachers = await db.Teachers.AsNoTracking().OrderBy(teacher => teacher.Surname).ToListAsync();
}
