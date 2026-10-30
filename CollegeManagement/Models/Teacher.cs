namespace CollegeManagement.Models;

public class Teacher : Person
{
    private string _subject;
    private int _experience;

    public int TeacherId { get; private set; }
    public string Name => _name;
    public string Surname => _surname;
    public string Subject { get => _subject; set => _subject = value; }
    public int Experience => _experience;

    public Teacher(string name, string surname, int age, string subject, int experience)
        : base(name, surname, age)
    {
        if (string.IsNullOrWhiteSpace(subject)) throw new ArgumentException("Предмет обязателен.", nameof(subject));
        if (experience < 0) throw new ArgumentOutOfRangeException(nameof(experience));
        _subject = subject;
        _experience = experience;
    }

    public Teacher() : this("Не указано", "Не указано", 25, "Не указан", 0) { }

    public void UpdateExperience(int experience)
    {
        if (experience < 0) throw new ArgumentOutOfRangeException(nameof(experience));
        _experience = experience;
    }

    public string GetTeacherInfo() => $"{GetFullName()}, предмет: {Subject}, стаж: {Experience} лет";
}
