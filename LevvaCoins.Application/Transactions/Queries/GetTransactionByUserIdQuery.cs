using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LevvaCoins.Application.Transactions.Dtos;
using LevvaCoins.Domain.Common;
using LevvaCoins.Domain.Common.Dtos;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Interfaces.Repositories;
using MediatR;

namespace LevvaCoins.Application.Transactions.Queries
{
    public class GetTransactionByUserIdQuery : IRequest<PagedResultDto<Transaction>>
    {
        public Guid UserId { get; set; }
        public PaginationOptions PaginationOpt { get; set; }

        public GetTransactionByUserIdQuery(Guid userId, PaginationOptions paginationOpt)
        {
            UserId = userId;
            PaginationOpt = paginationOpt;
        }
    }

    public class GetTransactionByUserIdQueryHandler : IRequestHandler<GetTransactionByUserIdQuery, PagedResultDto<Transaction>>
    {
        readonly ITransactionRepository _transactionRepository;
        readonly IMapper _mapper;

        public GetTransactionByUserIdQueryHandler(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<PagedResultDto<Transaction>> Handle(GetTransactionByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _transactionRepository.GetTransactionByUser(request.UserId, request.PaginationOpt!);
        }
    }
}
