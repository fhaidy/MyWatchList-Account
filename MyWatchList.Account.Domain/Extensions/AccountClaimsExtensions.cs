using System.Security.Claims;

namespace MyWatchList.Account.Domain.Extensions
{
    public static class AccountClaimsExtensions
    {
        public static IEnumerable<Claim> GetClaims(this Domain.Account account)
        {
            var result = new List<Claim>
            {
                new Claim(ClaimTypes.Authentication, account.PasswordHash),
                new Claim(ClaimTypes.Email, account.Email),
            };
            return result;
        }
    }
}
