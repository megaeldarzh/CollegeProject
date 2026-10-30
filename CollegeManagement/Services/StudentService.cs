using CollegeManagement.Models;

namespace CollegeManagement.Services;

public class StudentService
{
    private readonly List<Student> _students = new();
    public IReadOnlyCollection<Student> GetStudents() => _students.AsReadOnly();

    public void Add(Student student)
    {
        ArgumentNullException.ThrowIfNull(student);
        if (_students.All(item => item.StudentId != student.StudentId)) _students.Add(student);
    }
}
