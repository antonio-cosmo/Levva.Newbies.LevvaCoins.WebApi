using LevvaCoins.Application.Commands.Interfaces.User;
using LevvaCoins.Application.Commands.Requests.User;
using LevvaCoins.Application.Services.Interfaces;

namespace LevvaCoins.Application.Commands.Handlers.User;

public class RemoveUserHandler : IRemoveUserHandler
{
    private readonly IUserServices _userServices;

    public RemoveUserHandler(IUserServices userServices)
    {
        _userServices = userServices;
    }

    public async Task Handle(RemoveUserRequest request, CancellationToken cancellationToken)
    {
        await _userServices.RemoveAsync(request.Id, cancellationToken);
    }
}