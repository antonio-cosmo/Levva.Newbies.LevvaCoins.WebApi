using LevvaCoins.Application.Commands.Interfaces.User;
using LevvaCoins.Application.Commands.Requests.User;
using LevvaCoins.Application.Services.Interfaces;

namespace LevvaCoins.Application.Commands.Handlers.User;

public class UpdateUserHandler : IUpdateUserHandler
{
    private readonly IUserServices _userServices;

    public UpdateUserHandler(IUserServices userServices)
    {
        _userServices = userServices;
    }

    public async Task Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var updateRequest = new UpdateUserRequest(
            request.Id,
            request.Name,
            request.Avatar
        );
        await _userServices.UpdateAsync(updateRequest, cancellationToken);
    }
}