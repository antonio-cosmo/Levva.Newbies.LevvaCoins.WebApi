using System.Security.Claims;

namespace LevvaCoins.Application.Users.Extensions
{
    public static class ClaimsPrinncipalExtension
    {
        public static Guid GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            var userGuid = claimsPrincipal.Identity?.Name
                ?? throw new NullReferenceException("referencia nula para id de usuario");

            return new Guid(userGuid) ;
        }
    }
}
