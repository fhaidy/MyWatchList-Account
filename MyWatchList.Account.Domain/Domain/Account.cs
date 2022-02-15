using System.ComponentModel.DataAnnotations;

namespace MyWatchList.Account.Domain.Domain
{
    public class Account
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public string PasswordHash { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }

        public Account(string username, string passwordHash, string email, DateTime creationDate)
        {
            PasswordHash = passwordHash;
            Email = email;
            CreationDate = creationDate;
        }

        public Account(string email)
        {
            Email = email;
            PasswordHash = string.Empty;
            CreationDate = DateTime.MinValue;
        }
    }
}
