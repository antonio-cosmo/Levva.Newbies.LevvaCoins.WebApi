using System.Security.Claims;

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
