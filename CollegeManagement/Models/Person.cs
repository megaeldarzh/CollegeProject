namespace CollegeManagement.Models;

public abstract class Person
{
    protected string _name;
    protected string _surname;
    protected int _age;

    protected Person(string name, string surname, int age)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Имя обязательно.", nameof(name));
        if (string.IsNullOrWhiteSpace(surname)) throw new ArgumentException("Фамилия обязательна.", nameof(surname));
        _name = name;
        _surname = surname;
        _age = age;
    }

    protected string DisplayBasicInfo() => $"{_name} {_surname}, {_age} лет";

    protected internal string GetFullName() => $"{_name} {_surname}";

    private protected int CalculateStatistics() => _age;
}
