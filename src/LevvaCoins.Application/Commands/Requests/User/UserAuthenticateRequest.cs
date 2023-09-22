using LevvaCoins.Application.Responses;
using MediatR;

namespace LevvaCoins.Application.Commands.Requests.User;

public class UserAuthenticateRequest : IRequest<UserAuthenticateModelResponse>
{
    public UserAuthenticateRequest(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public string Email { get; set; }
    public string Password { get; set; }
}