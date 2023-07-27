using LevvaCoins.Application.Exceptions;
using LevvaCoins.Application.UseCases.Users.Helpers;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.SeedWork;
using Microsoft.Extensions.Configuration;

namespace LevvaCoins.Application.UseCases.Users.UserAuthenticate;

public class UserAuthenticate : IUserAuthenticate
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConfiguration _configuration;
    public UserAuthenticate(IUnitOfWork unitOfWork, IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _configuration = configuration;
    }
    public async Task<UserAuthenticateModelOutput> Handle(UserAuthenticateInput request, CancellationToken cancellationToken)
    {
        var user = await FindUser(request, cancellationToken);

        return new UserAuthenticateModelOutput(
                user.Id,
                user.Name,
                user.Email,
                user.Avatar,
                TokenJwt.Generate(user, _configuration)
            );
    }

    private async Task<User> FindUser(UserAuthenticateInput authenticateUser, CancellationToken cancellationToken)
    {
        var passwordHash = new PasswordHash(authenticateUser.Password).HashedValue;
        var email = authenticateUser.Email;

        return await _unitOfWork.UserRepository.GetByEmailAndPasswordAsync(email, passwordHash, cancellationToken)
            ?? throw new NotAuthorizedException("Usuário ou senha inválidos.");
    }
}
