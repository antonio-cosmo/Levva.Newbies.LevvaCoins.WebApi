using LevvaCoins.Application.UseCases.Users.Queries;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Repositories;
using MediatR;

namespace LevvaCoins.Application.UseCases.Users.Handlers
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, User?>
    {
        readonly IUserRepository _userRepository;

        public GetUserByEmailQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken) =>
            await _userRepository.GetByEmailAsync(request.Email, cancellationToken);


    }
}
