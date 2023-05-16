using AutoMapper;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Interfaces.Repositories;
using MediatR;

namespace LevvaCoins.Application.Accounts.Queries
{
    public class GetAccountByIdQuery : IRequest<User?>
    {
        public Guid Id { get; set; }

        public GetAccountByIdQuery(Guid id)
        {
            Id = id;
        }
    }

    public class GetAccountByIdQueryHandler : IRequestHandler<GetAccountByIdQuery, User?>
    {
        readonly IUserRepository _userRepository;
        readonly IMapper _mapper;

        public GetAccountByIdQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<User?> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetByIdAsync(request.Id);

        }
    }
}
