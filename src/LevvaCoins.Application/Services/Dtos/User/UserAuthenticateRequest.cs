using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevvaCoins.Application.Services.Dtos.User;
public class UserAuthenticateRequest
{
    public string Email { get; set; }
    public string Password { get; set; }

    public UserAuthenticateRequest(string email, string password)
    {
        Email = email;
        Password = password;
    }
}
