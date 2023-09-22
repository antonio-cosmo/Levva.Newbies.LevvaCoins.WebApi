using LevvaCoins.Application.Queries.Interfaces.User;
using LevvaCoins.Application.Queries.Requests.User;
using LevvaCoins.Application.Responses;
using LevvaCoins.Application.Services.Interfaces;

namespace LevvaCoins.Application.Queries.Handlers.User;

public class GetAllUsersHandler : IGetAllUsersHandler
{
    private readonly IUserServices _userServices;

    public GetAllUsersHandler(IUserServices userServices)
    {
        _userServices = userServices;
    }

    public async Task<IEnumerable<UserModelResponse>> Handle(GetAllUsersRequest request,
        CancellationToken cancellationToken)
    {
        return await _userServices.GetAllAsync(cancellationToken);
    }
}