using CollegeManagement.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CollegeManagement.Pages;

public class AdminModel(UserAccount account) : PageModel
{
    public string Message { get; private set; } = string.Empty;

    public void OnGet()
    {
        Message = account.IsLoggedIn ? "Вы вошли как администратор." : "Демонстрационная панель администратора. Для входа используйте страницу авторизации.";
    }
}
