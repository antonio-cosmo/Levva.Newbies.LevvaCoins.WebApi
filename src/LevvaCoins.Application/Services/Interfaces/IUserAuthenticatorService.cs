using LevvaCoins.Application.Commands.Requests.User;
using LevvaCoins.Application.Responses;

namespace LevvaCoins.Application.Services.Interfaces;

public interface IUserAuthenticatorService
{
    Task<UserAuthenticateModelResponse> Authenticate(UserAuthenticateRequest request,
        CancellationToken cancellationToken);
}