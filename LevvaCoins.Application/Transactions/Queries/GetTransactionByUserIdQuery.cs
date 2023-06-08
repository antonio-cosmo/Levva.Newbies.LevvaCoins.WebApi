using AutoMapper;
using LevvaCoins.Domain.Common;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Interfaces.Repositories;
using MediatR;

namespace LevvaCoins.Application.Transactions.Queries
{
    public class GetTransactionByUserIdQuery : IRequest<PagedResult<Transaction>>
    {
        public Guid UserId { get; set; }
        public PaginationOptions PaginationOpt { get; set; }

        public GetTransactionByUserIdQuery(Guid userId, PaginationOptions paginationOpt)
        {
            UserId = userId;
            PaginationOpt = paginationOpt;
        }
    }

    public class GetTransactionByUserIdQueryHandler : IRequestHandler<GetTransactionByUserIdQuery, PagedResult<Transaction>>
    {
        readonly ITransactionRepository _transactionRepository;
        readonly IMapper _mapper;

        public GetTransactionByUserIdQueryHandler(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<Transaction>> Handle(GetTransactionByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _transactionRepository.GetbyUserIdAndIncludeCategory(request.UserId, request.PaginationOpt!);
        }
    }
}
