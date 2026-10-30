using CollegeManagement.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CollegeManagement.Pages;

public class AttendanceModel(AttendanceManager attendanceManager) : PageModel
{
    public (int Total, int Present, double Percentage) Statistics { get; private set; }

    public void OnGet()
    {
        if (attendanceManager.GetStatistics(1).Total == 0)
        {
            attendanceManager.AddAttendance(1, true);
            attendanceManager.AddAttendance(1, true);
            attendanceManager.AddAttendance(1, false);
        }
        Statistics = attendanceManager.GetStatistics(1);
    }
}
