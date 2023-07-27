using MediatR;

namespace LevvaCoins.Application.UseCases.Users.UserAuthenticate;

public interface IUserAuthenticate : IRequestHandler<UserAuthenticateInput, UserAuthenticateModelOutput>
{
}
