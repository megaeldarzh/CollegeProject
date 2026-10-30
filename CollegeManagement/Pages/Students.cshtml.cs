using CollegeManagement.Data;
using CollegeManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CollegeManagement.Pages;

public class StudentsModel(CollegeDbContext db) : PageModel
{
    public IReadOnlyCollection<Student> Students { get; private set; } = Array.Empty<Student>();

    public async Task OnGetAsync() => Students = await db.Students.AsNoTracking().OrderBy(student => student.Surname).ToListAsync();
}
