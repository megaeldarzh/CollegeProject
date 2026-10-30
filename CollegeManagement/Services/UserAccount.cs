using System.Security.Cryptography;
using System.Text;

namespace CollegeManagement.Services;

public class UserAccount
{
    private readonly string _login;
    private readonly string _passwordHash;
    private bool _isLoggedIn;

    public UserAccount(IConfiguration configuration)
    {
        _login = configuration["AdminAccount:Login"] ?? "admin";
        _passwordHash = configuration["AdminAccount:PasswordHash"] ?? HashPassword("admin123");
    }

    public bool Login(string login, string password)
    {
        _isLoggedIn = login == _login && HashPassword(password) == _passwordHash;
        return _isLoggedIn;
    }

    public void Logout() => _isLoggedIn = false;
    public bool IsLoggedIn => _isLoggedIn;
    public string GetAccountInfo() => $"Пользователь: {_login}, авторизация: {_isLoggedIn}";

    private static string HashPassword(string password)
    {
        var hash = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        return Convert.ToHexString(hash);
    }
}
