using LevvaCoins.Application.UseCases.Users.Queries;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Repositories;
using MediatR;

namespace LevvaCoins.Application.UseCases.Users.Handlers
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, IEnumerable<User>>
    {
        readonly IUserRepository _userRepository;

        public GetAllUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> Handle(GetAllUserQuery request, CancellationToken cancellationToken) =>
            await _userRepository.GetAllAsync(cancellationToken);

    }
}
