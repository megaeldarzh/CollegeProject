namespace CollegeManagement.Models;

public abstract class User
{
    protected string UserName { get; }
    protected string Role { get; }

    protected User(string userName, string role)
    {
        UserName = userName;
        Role = role;
    }

    public string GetUserInfo() => $"{UserName} ({Role})";
}

public sealed class Admin(string userName) : User(userName, "Администратор");
public sealed class TeacherUser(string userName) : User(userName, "Преподаватель");
public sealed class StudentUser(string userName) : User(userName, "Студент");
