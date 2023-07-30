using LevvaCoins.Application.Services.Dtos.User;

namespace LevvaCoins.Application.Services.Interfaces;
public interface IUserAuthenticatorService
{
    Task<UserAuthenticateModelResponse> Authenticate(UserAuthenticateRequest request, CancellationToken cancellationToken);
}
