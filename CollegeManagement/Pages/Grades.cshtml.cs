using CollegeManagement.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CollegeManagement.Pages;

public class GradesModel(GradeBook gradeBook) : PageModel
{
    public int Count => gradeBook.Grades.Count;

    public void OnGet()
    {
        if (gradeBook.Grades.Count == 0) gradeBook.AddGrade(1, 1, 5);
    }
}
