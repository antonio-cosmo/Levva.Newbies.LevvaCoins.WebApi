using LevvaCoins.Application.Commands.Requests.User;
using MediatR;

namespace LevvaCoins.Application.Commands.Interfaces.User;

public interface IRemoveUserHandler : IRequestHandler<RemoveUserRequest>
{
}