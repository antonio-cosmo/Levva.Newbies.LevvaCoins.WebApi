using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using LevvaCoins.Domain.Entities;

namespace LevvaCoins.Application.Accounts.Extensions
{
    public static class RoleClaimsExtension
    {
        public static IEnumerable<Claim> GetClaims(this User user)
        {

            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Name! ),
                new Claim("id", user.Id.ToString())
            };

            return claims;
        }
    }
}
