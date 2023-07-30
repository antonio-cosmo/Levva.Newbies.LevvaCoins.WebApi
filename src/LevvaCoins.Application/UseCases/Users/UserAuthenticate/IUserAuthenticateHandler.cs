using LevvaCoins.Application.Services.Dtos.User;
using MediatR;

namespace LevvaCoins.Application.UseCases.Users.UserAuthenticate;

public interface IUserAuthenticateHandler : IRequestHandler<UserAuthenticate, UserAuthenticateModelResponse>
{
}
