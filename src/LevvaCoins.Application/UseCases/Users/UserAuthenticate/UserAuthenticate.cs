using LevvaCoins.Application.Responses;
using MediatR;

namespace LevvaCoins.Application.UseCases.Users.UserAuthenticate;

public class UserAuthenticate : IRequest<UserAuthenticateModelResponse>
{
    public UserAuthenticate(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public string Email { get; set; }
    public string Password { get; set; }
}