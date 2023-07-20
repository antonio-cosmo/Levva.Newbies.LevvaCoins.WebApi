using LevvaCoins.Application.Exceptions;
using LevvaCoins.Application.UseCases.Users.Helpers;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Repositories;
using Microsoft.Extensions.Configuration;

namespace LevvaCoins.Application.UseCases.Users.AuthenticateUser
{
    public class AuthenticateUser : IAuthenticateUser
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        public AuthenticateUser(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }
        public async Task<AuthenticateUserOutput> Handle(AuthenticateUserInput request, CancellationToken cancellationToken)
        {
            var user = await FindUser(request, cancellationToken);

            return new AuthenticateUserOutput(
                    user.Id,
                    user.Name,
                    user.Email,
                    user.Avatar,
                    TokenJwt.Generate(user, _configuration)
                );
        }

        private async Task<User> FindUser(AuthenticateUserInput authenticateUser, CancellationToken cancellationToken)
        {
            var passwordHash = new PasswordHash(authenticateUser.Password).HashedValue;
            var email = authenticateUser.Email;
            return await _userRepository.GetByEmailAndPasswordAsync(email, passwordHash, cancellationToken)
                ?? throw new NotAuthorizedException("Usuário ou senha inválidos.");
        }
    }
}
