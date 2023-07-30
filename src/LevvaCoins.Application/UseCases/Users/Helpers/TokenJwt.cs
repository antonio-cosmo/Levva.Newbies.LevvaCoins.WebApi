using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LevvaCoins.Application.Extensions;
using LevvaCoins.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace LevvaCoins.Application.UseCases.Users.Helpers;
public static class TokenJwt
{
    public static string Generate(User user, IConfiguration configuration)
    {
        var userClaims = user.GetClaims();

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(configuration.GetValue<string>("SecretKey")!);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(userClaims),
            Expires = DateTime.UtcNow.AddHours(8),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return $"Bearer {tokenHandler.WriteToken(token)}";
    }
}
