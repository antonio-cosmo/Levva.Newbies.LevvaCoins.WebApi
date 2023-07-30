using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevvaCoins.Application.Services.Dtos.User;
public class CreateUserRequest
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Avatar { get; set; }

    public CreateUserRequest(string name, string email, string password, string avatar)
    {
        Name = name;
        Email = email;
        Password = password;
        Avatar = avatar;
    }
}
