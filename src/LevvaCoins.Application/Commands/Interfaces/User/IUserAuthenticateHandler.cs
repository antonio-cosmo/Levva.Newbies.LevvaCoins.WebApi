using LevvaCoins.Application.Commands.Requests.User;
using LevvaCoins.Application.Responses;
using MediatR;

namespace LevvaCoins.Application.Commands.Interfaces.User;

public interface IUserAuthenticateHandler : IRequestHandler<UserAuthenticateRequest, UserAuthenticateModelResponse>
{
}