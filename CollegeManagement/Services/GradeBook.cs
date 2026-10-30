using CollegeManagement.Models;

namespace CollegeManagement.Services;

public class GradeBook
{
    private readonly List<Grade> _grades = new();
    public IReadOnlyCollection<Grade> Grades => _grades.AsReadOnly();

    public bool AddGrade(int studentId, int subjectId, int value)
    {
        if (studentId <= 0 || subjectId <= 0) return false;
        if (value is < 2 or > 5) return false;
        _grades.Add(new Grade(studentId, subjectId, value, DateTime.UtcNow));
        return true;
    }

    public bool UpdateGrade(Grade oldGrade, int value)
    {
        if (value is < 2 or > 5) return false;
        var index = _grades.IndexOf(oldGrade);
        if (index < 0) return false;
        _grades[index] = oldGrade with { Value = value };
        return true;
    }

    public bool RemoveGrade(int studentId, int subjectId, DateTime date)
    {
        var grade = _grades.FirstOrDefault(item => item.StudentId == studentId && item.SubjectId == subjectId && item.Date == date);
        return grade is not null && _grades.Remove(grade);
    }
}
