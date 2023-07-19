using LevvaCoins.Application.Exceptions;
using LevvaCoins.Application.UseCases.Users.Common;
using LevvaCoins.Domain.Repositories;

namespace LevvaCoins.Application.UseCases.Users.GetUser
{
    public class GetUser : IGetUser
    {
        readonly IUserRepository _userRepository;

        public GetUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserOutput?> Handle(GetUserInput request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(request.Id, cancellationToken)
                ?? throw new ModelNotFoundException("Esse usuário não existe.");
            return UserOutput.FromDomain(user);
        }
    }
}
