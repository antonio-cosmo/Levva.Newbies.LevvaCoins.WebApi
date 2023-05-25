using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Interfaces.Repositories;
using MediatR;

namespace LevvaCoins.Application.Accounts.Queries
{
    public class GetAccountByEmailQuery : IRequest<User?>
    {
        public string Email { get; set; }

        public GetAccountByEmailQuery(string email)
        {
            Email = email;
        }
    }

    public class GetAccountByEmailQueryHandler : IRequestHandler<GetAccountByEmailQuery, User?>
    {
        readonly IUserRepository _userRepository;

        public GetAccountByEmailQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> Handle(GetAccountByEmailQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetByEmailAsync(request.Email);

        }
    }
}
