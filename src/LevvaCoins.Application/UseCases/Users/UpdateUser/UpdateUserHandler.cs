using LevvaCoins.Application.Services.Dtos.User;
using LevvaCoins.Application.Services.Interfaces;

namespace LevvaCoins.Application.UseCases.Users.UpdateUser;

public class UpdateUserHandler : IUpdateUserHandler
{
    private readonly IUserServices _userServices;

    public UpdateUserHandler(IUserServices userServices)
    {
        _userServices = userServices;
    }

    public async Task Handle(UpdateUser request, CancellationToken cancellationToken)
    {
        var updateRequest = new UpdateUserRequest(
                request.Id,
                request.Name,
                request.Avatar
            );
        await _userServices.UpdateAsync( updateRequest, cancellationToken );
    }
}
