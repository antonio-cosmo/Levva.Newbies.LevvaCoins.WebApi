using LevvaCoins.Application.Services.Interfaces;

namespace LevvaCoins.Application.UseCases.Users.RemoveUser;

public class RemoveUserHandler : IRemoveUserHandler
{
    private readonly IUserServices _userServices;

    public RemoveUserHandler(IUserServices userServices)
    {
        _userServices = userServices;
    }

    public async Task Handle(RemoveUser request, CancellationToken cancellationToken)
    {
        await _userServices.RemoveAsync(request.Id, cancellationToken);
    }
}
