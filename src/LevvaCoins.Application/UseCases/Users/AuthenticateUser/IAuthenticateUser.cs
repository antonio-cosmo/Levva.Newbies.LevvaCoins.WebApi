using MediatR;

namespace LevvaCoins.Application.UseCases.Users.AuthenticateUser;

public interface IAuthenticateUser : IRequestHandler<AuthenticateUserInput, AuthenticateUserOutput>
{
}
