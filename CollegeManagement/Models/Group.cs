namespace CollegeManagement.Models;

public class Group
{
    private readonly List<Student> _students = new();

    public int GroupId { get; private set; }
    public string Name { get; private set; }
    public int Course { get; private set; }
    public IReadOnlyCollection<Student> Students => _students.AsReadOnly();

    public Group(string name, int course)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Название группы обязательно.", nameof(name));
        if (course is < 1 or > 6) throw new ArgumentOutOfRangeException(nameof(course));
        Name = name;
        Course = course;
    }

    public Group() : this("Не указана", 1) { }

    public bool AddStudent(Student student)
    {
        ArgumentNullException.ThrowIfNull(student);
        if (_students.Any(item => item.StudentId == student.StudentId)) return false;
        _students.Add(student);
        return true;
    }

    public bool RemoveStudent(int studentId)
    {
        var student = _students.FirstOrDefault(item => item.StudentId == studentId);
        return student is not null && _students.Remove(student);
    }
}
