using System.Security.Claims;
using LevvaCoins.Domain.Entities;

namespace LevvaCoins.Application.Extensions
{
    public static class RoleClaimsExtension
    {
        public static IEnumerable<Claim> GetClaims(this User user)
        {
            return new List<Claim> {
                new Claim(ClaimTypes.Name, user.Id.ToString() ??  throw new NullReferenceException()),
                new Claim(ClaimTypes.Email, user.Email )
            };
        }
    }
}
