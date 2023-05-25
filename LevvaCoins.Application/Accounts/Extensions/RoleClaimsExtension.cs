using System.Security.Claims;
using LevvaCoins.Domain.Entities;

namespace LevvaCoins.Application.Accounts.Extensions
{
    public static class RoleClaimsExtension
    {
        public static IEnumerable<Claim> GetClaims(this User user)
        {

            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Email ),
                new Claim("id", user.Id.ToString()!)
            };

            return claims;
        }
    }
}
