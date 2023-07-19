using LevvaCoins.Application.Exceptions;
using LevvaCoins.Application.UseCases.Users.Helpers;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Repositories;

namespace LevvaCoins.Application.UseCases.Users.AuthenticateUser
{
    public class AuthenticateUser : IAuthenticateUser
    {
        private readonly IUserRepository _userRepository;

        public AuthenticateUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<AuthenticateUserOutput> Handle(AuthenticateUserInput request, CancellationToken cancellationToken)
        {
            var user = await FindUser(request, cancellationToken);

            return new AuthenticateUserOutput(
                    user.Id,
                    user.Name,
                    user.Email,
                    user.Avatar,
                    TokenJwt.Generate(user)
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
