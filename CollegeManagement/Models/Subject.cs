namespace CollegeManagement.Models;

public class Subject
{
    private string _name;
    private int _hours;
    private Teacher? _teacher;

    public int SubjectId { get; private set; }
    public string Name => _name;
    public int Hours => _hours;
    public Teacher? Teacher => _teacher;

    public Subject(string name, int hours)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Название предмета обязательно.", nameof(name));
        if (hours <= 0) throw new ArgumentOutOfRangeException(nameof(hours));
        _name = name;
        _hours = hours;
    }

    public Subject() : this("Не указан", 1) { }

    public void AssignTeacher(Teacher teacher) => _teacher = teacher ?? throw new ArgumentNullException(nameof(teacher));
}
