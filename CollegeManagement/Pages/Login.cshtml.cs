using System.ComponentModel.DataAnnotations;
using CollegeManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CollegeManagement.Pages;

public class LoginModel(UserAccount account) : PageModel
{
    [BindProperty, Required] public string Login { get; set; } = string.Empty;
    [BindProperty, Required, DataType(DataType.Password)] public string Password { get; set; } = string.Empty;

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid) return Page();
        if (!account.Login(Login, Password))
        {
            ModelState.AddModelError(string.Empty, "Неверный логин или пароль.");
            return Page();
        }
        return RedirectToPage("/Admin");
    }
}
