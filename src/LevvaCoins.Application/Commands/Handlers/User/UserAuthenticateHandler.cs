using LevvaCoins.Application.Commands.Interfaces.User;
using LevvaCoins.Application.Commands.Requests.User;
using LevvaCoins.Application.Responses;
using LevvaCoins.Application.Services.Interfaces;

namespace LevvaCoins.Application.Commands.Handlers.User;

public class UserAuthenticateHandler : IUserAuthenticateHandler
{
    private readonly IUserAuthenticatorService _userAuthenticatorService;

    public UserAuthenticateHandler(IUserAuthenticatorService userAuthenticatorService)
    {
        _userAuthenticatorService = userAuthenticatorService;
    }

    public async Task<UserAuthenticateModelResponse> Handle(UserAuthenticateRequest request,
        CancellationToken cancellationToken)
    {
        return await _userAuthenticatorService.Authenticate(
            new UserAuthenticateRequest(request.Email, request.Password), cancellationToken);
    }
}