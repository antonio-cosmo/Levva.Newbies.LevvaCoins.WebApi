using LevvaCoins.Application.Services.Dtos.User;
using MediatR;

namespace LevvaCoins.Application.UseCases.Users.UserAuthenticate;
public class UserAuthenticate : IRequest<UserAuthenticateModelResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }

    public UserAuthenticate(string email, string password)
    {
        Email = email;
        Password = password;
    }
}
