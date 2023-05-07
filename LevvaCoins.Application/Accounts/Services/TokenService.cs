using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LevvaCoins.Application.Accounts.Extensions;
using LevvaCoins.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace LevvaCoins.Application.Accounts.Services
{
    public static class TokenService
    {
        public static string GenereteToken(User user, IConfiguration configuration)
        {
            if (user == null) throw new ArgumentNullException();

            var userClaims = user.GetClaims();


            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration.GetValue<string>("Token:Key")!);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(userClaims),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
