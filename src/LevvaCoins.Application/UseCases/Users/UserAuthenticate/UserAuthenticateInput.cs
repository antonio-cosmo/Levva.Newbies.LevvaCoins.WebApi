using MediatR;

namespace LevvaCoins.Application.UseCases.Users.UserAuthenticate;
public class UserAuthenticateInput : IRequest<UserAuthenticateModelOutput>
{
    public string Email { get; set; }
    public string Password { get; set; }

    public UserAuthenticateInput(string email, string password)
    {
        Email = email;
        Password = password;
    }
}
