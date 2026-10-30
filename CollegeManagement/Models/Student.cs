namespace CollegeManagement.Models;

public class Student : Person
{
    private string _group;

    public int StudentId { get; private set; }
    public string Name { get => _name; set => _name = value; }
    public string Surname { get => _surname; set => _surname = value; }
    public int Age { get => _age; private set => SetAge(value); }
    public string Group { get => _group; set => _group = value; }

    public Student(string name, string surname, int age, string group)
        : base(name, surname, age)
    {
        ValidateStudentData(name, surname, age, group);
        _name = name;
        _surname = surname;
        _age = age;
        _group = group;
    }

    public Student() : this("Не указано", "Не указано", 15, "Не указана") { }

    public void SetAge(int age)
    {
        if (age is < 15 or > 70)
            throw new ArgumentOutOfRangeException(nameof(age), "Возраст должен быть от 15 до 70 лет.");
        _age = age;
    }

    public string GetStudentInfo() => $"{StudentId}: {Name} {Surname}, {Age} лет, группа {Group}";

    private void ValidateStudentData(string name, string surname, int age, string group)
    {
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) || string.IsNullOrWhiteSpace(group))
            throw new ArgumentException("Имя, фамилия и группа обязательны.");
        if (age is < 15 or > 70)
            throw new ArgumentOutOfRangeException(nameof(age), "Возраст должен быть от 15 до 70 лет.");
    }
}
