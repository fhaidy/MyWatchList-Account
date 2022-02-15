using System.ComponentModel.DataAnnotations;

namespace MyWatchList.Account.Domain.Domain.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "Email required")]
    [EmailAddress(ErrorMessage = "Invalid Email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }
}