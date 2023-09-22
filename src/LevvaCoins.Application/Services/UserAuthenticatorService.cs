using LevvaCoins.Application.Commands.Requests.User;
using LevvaCoins.Application.Common;
using LevvaCoins.Application.Responses;
using LevvaCoins.Application.Services.Helpers;
using LevvaCoins.Application.Services.Interfaces;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.SeedWork;
using Microsoft.Extensions.Configuration;

namespace LevvaCoins.Application.Services;

public class UserAuthenticatorService : IUserAuthenticatorService
{
    private readonly IConfiguration _configuration;
    private readonly IUnitOfWork _unitOfWork;
    private readonly NotificationContext _notificationContext;

    public UserAuthenticatorService(IUnitOfWork unitOfWork, IConfiguration configuration, NotificationContext notificationContext)
    {
        _unitOfWork = unitOfWork;
        _configuration = configuration;
        _notificationContext = notificationContext;
    }

    public async Task<UserAuthenticateModelResponse> Authenticate(UserAuthenticateRequest request,
        CancellationToken cancellationToken)
    {
        var user = await FindUser(request, cancellationToken);
        
        if (user is not null)
            return new UserAuthenticateModelResponse(
                user.Id,
                user.Name,
                user.Email,
                user.Avatar,
                TokenJwt.Generate(user, _configuration)
            );
        
        _notificationContext.AddNotification("Excption","Usuário ou senha inválidos.");
        return null;
    }

    private async Task<User?> FindUser(UserAuthenticateRequest userAuthenticateRequest,
        CancellationToken cancellationToken)
    {
        var passwordHash = new PasswordHash(userAuthenticateRequest.Password).HashedValue;
        var email = userAuthenticateRequest.Email;

        return await _unitOfWork.UserRepository.GetByPredicateAsync(x => x.Email == email && x.Password == passwordHash,
                   cancellationToken);
    }
}