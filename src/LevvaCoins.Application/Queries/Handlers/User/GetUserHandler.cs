using LevvaCoins.Application.Queries.Interfaces.User;
using LevvaCoins.Application.Queries.Requests.User;
using LevvaCoins.Application.Responses;
using LevvaCoins.Application.Services.Interfaces;

namespace LevvaCoins.Application.Queries.Handlers.User;

public class GetUserHandler : IGetUserHandler
{
    private readonly IUserServices _userServices;

    public GetUserHandler(IUserServices userServices)
    {
        _userServices = userServices;
    }

    public async Task<UserModelResponse?> Handle(GetUserRequest request, CancellationToken cancellationToken)
    {
        return await _userServices.GetAsync(request.Id, cancellationToken);
    }
}