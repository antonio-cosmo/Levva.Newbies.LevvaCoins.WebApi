using MediatR;

namespace LevvaCoins.Application.UseCases.Users.AuthenticateUser;
public class AuthenticateUserInput : IRequest<AuthenticateUserOutput>
{
    public string Email { get; set; }
    public string Password { get; set; }

    public AuthenticateUserInput(string email, string password)
    {
        Email = email;
        Password = password;
    }
}
