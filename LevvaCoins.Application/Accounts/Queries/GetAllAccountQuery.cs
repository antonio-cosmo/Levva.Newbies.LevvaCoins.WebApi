using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Interfaces.Repositories;
using MediatR;

namespace LevvaCoins.Application.Accounts.Queries
{
    public class GetAllAccountQuery : IRequest<IEnumerable<User>>
    {
    }

    public class GetAllAccountQueryHandler : IRequestHandler<GetAllAccountQuery, IEnumerable<User>>
    {
        readonly IUserRepository _userRepository;

        public GetAllAccountQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> Handle(GetAllAccountQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetAllAsync();
        }
    }
}
