using AutoMapper;
using LevvaCoins.Application.Transactions.Queries;
using LevvaCoins.Domain.Common;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Interfaces.Repositories;
using MediatR;

namespace LevvaCoins.Application.Transactions.Handlers
{
    public class GetAllTransactionByUserPagedQueryHandler : IRequestHandler<Queries.GetAllTransactionByUserPagedQuery, PagedResult<Transaction>>
    {
        readonly ITransactionRepository _transactionRepository;
        readonly IMapper _mapper;

        public GetAllTransactionByUserPagedQueryHandler(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<Transaction>> Handle(Queries.GetAllTransactionByUserPagedQuery request, CancellationToken cancellationToken)
        {
            return await _transactionRepository.GetByUserPagedAsync(request.UserId, request.PaginationOpt!);
        }
    }
}
