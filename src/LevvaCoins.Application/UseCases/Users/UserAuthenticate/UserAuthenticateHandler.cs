using LevvaCoins.Application.Services.Dtos.User;
using LevvaCoins.Application.Services.Interfaces;

namespace LevvaCoins.Application.UseCases.Users.UserAuthenticate;

public class UserAuthenticateHandler : IUserAuthenticateHandler
{
    private readonly IUserAuthenticatorService _userAuthenticatorService;
public UserAuthenticateHandler(IUserAuthenticatorService userAuthenticatorService)
    {
        _userAuthenticatorService = userAuthenticatorService;
    }

    public async Task<UserAuthenticateModelResponse> Handle(UserAuthenticate request, CancellationToken cancellationToken)
    {
        return await _userAuthenticatorService.Authenticate(new(request.Email, request.Password),cancellationToken);
    }
}
