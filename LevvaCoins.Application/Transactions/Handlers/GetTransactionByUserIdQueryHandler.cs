using AutoMapper;
using LevvaCoins.Application.Transactions.Queries;
using LevvaCoins.Domain.Common;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Interfaces.Repositories;
using MediatR;

namespace LevvaCoins.Application.Transactions.Handlers
{
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
            return await _transactionRepository.GetByUserIdAndIncludeCategoryAsync(request.UserId, request.PaginationOpt!);
        }
    }
}
