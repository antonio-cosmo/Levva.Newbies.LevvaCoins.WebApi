using LevvaCoins.Application.Accounts.Queries;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Interfaces.Repositories;
using MediatR;

namespace LevvaCoins.Application.Accounts.Handlers
{
    public class GetAccountByIdQueryHandler : IRequestHandler<GetAccountByIdQuery, User?>
    {
        readonly IUserRepository _userRepository;

        public GetAccountByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetByIdAsync(request.Id);

        }
    }
}
