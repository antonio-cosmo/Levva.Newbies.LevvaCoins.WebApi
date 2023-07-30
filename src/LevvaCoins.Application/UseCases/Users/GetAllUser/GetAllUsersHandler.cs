using LevvaCoins.Application.Services.Dtos.User;
using LevvaCoins.Application.Services.Interfaces;

namespace LevvaCoins.Application.UseCases.Users.GetAllUser;
public class GetAllUsersHandler : IGetAllUsersHandler
{
    private readonly IUserServices _userServices;

    public GetAllUsersHandler(IUserServices userServices)
    {
        _userServices = userServices;
    }

    public async Task<IEnumerable<UserModelResponse>> Handle(GetAllUsers request, CancellationToken cancellationToken)
    {
        return await _userServices.GetAllAsync(cancellationToken);
    }
}
