using System.ComponentModel.DataAnnotations;

namespace MyWatchList.Account.Domain.Domain;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Username is required")]
    public string Username { get; set; }
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; }
}