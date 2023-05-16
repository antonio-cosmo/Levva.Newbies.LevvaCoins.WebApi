using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LevvaCoins.Application.Accounts.Dtos;
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
        readonly IMapper _mapper;

        public GetAllAccountQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<User>> Handle(GetAllAccountQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetAllAsync();
        }
    }
}
