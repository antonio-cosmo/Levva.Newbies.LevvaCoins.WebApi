using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevvaCoins.Application.UseCases.Users.AuthenticateUser;
public class AuthenticateUserOutput
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string? Avatar { get; set; }
    public string? Token { get; set; }

    public AuthenticateUserOutput(Guid id, string name, string email, string? avatar, string token)
    {
        Id = id;
        Name = name;
        Email = email;
        Avatar = avatar;
        Token = token;
    }
}
