using LevvaCoins.Application.Users.Queries;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Repositories;
using MediatR;

namespace LevvaCoins.Application.Users.Handlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User?>
    {
        readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken) =>
            await _userRepository.GetAsync(request.Id);

    }
}
