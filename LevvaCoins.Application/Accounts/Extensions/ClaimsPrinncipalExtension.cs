using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LevvaCoins.Application.Accounts.Extensions
{
    public static class ClaimsPrinncipalExtension
    {
        public static string GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            var userId = claimsPrincipal.FindFirst("id");
            if (userId == null) return "";
            return userId.Value;
        }
    }
}
