using LevvaCoins.Application.Exceptions;
using LevvaCoins.Application.Services.Dtos.User;
using LevvaCoins.Application.Services.Interfaces;
using LevvaCoins.Application.UseCases.Users.Helpers;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.SeedWork;
using Microsoft.Extensions.Configuration;

namespace LevvaCoins.Application.Services;
public class UserAuthenticatorService : IUserAuthenticatorService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConfiguration _configuration;

    public UserAuthenticatorService(IUnitOfWork unitOfWork, IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _configuration = configuration;
    }

    public async Task<UserAuthenticateModelResponse> Authenticate(UserAuthenticateRequest request, CancellationToken cancellationToken)
    {
        var user = await FindUser(request, cancellationToken);

        return new UserAuthenticateModelResponse(
                user.Id,
                user.Name,
                user.Email,
                user.Avatar,
                TokenJwt.Generate(user, _configuration)
            );
    }
    private async Task<User> FindUser(UserAuthenticateRequest userAuthenticateRequest, CancellationToken cancellationToken)
    {
        var passwordHash = new PasswordHash(userAuthenticateRequest.Password).HashedValue;
        var email = userAuthenticateRequest.Email;

        return await _unitOfWork.UserRepository.GetByEmailAndPasswordAsync(email, passwordHash, cancellationToken)
            ?? throw new NotAuthorizedException("Usuário ou senha inválidos.");
    }
}
