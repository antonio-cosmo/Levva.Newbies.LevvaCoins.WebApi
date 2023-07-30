using LevvaCoins.Application.Exceptions;
using LevvaCoins.Application.Services.Dtos.User;
using LevvaCoins.Application.Services.Interfaces;
using LevvaCoins.Domain.SeedWork;

namespace LevvaCoins.Application.UseCases.Users.GetUser;

public class GetUserHandler : IGetUserHandler
{
    private readonly IUserServices _userServices;

    public GetUserHandler(IUserServices userServices)
    {
        _userServices = userServices;
    }

    public async Task<UserModelResponse?> Handle(GetUser request, CancellationToken cancellationToken)
    {
        return await _userServices.GetAsync(request.Id, cancellationToken);
    }
}
