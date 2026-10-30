namespace CollegeManagement.Models;

internal class CollegeSettings
{
    public string CollegeName { get; private set; }
    public int AcademicYear { get; private set; }

    public CollegeSettings(string collegeName, int academicYear)
    {
        CollegeName = collegeName;
        AcademicYear = academicYear;
    }

    internal void Update(string collegeName, int academicYear)
    {
        CollegeName = collegeName;
        AcademicYear = academicYear;
    }
}
