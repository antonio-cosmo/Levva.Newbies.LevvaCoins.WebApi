using AutoMapper;
using LevvaCoins.Application.Transactions.Queries;
using LevvaCoins.Domain.Common;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Interfaces.Repositories;
using MediatR;

namespace LevvaCoins.Application.Transactions.Handlers
{
    public class GetAllTransactionByUserPagedQueryHandler : IRequestHandler<GetAllTransactionByUserPagedQuery, PagedResult<Transaction>>
    {
        readonly ITransactionRepository _transactionRepository;
        readonly IMapper _mapper;

        public GetAllTransactionByUserPagedQueryHandler(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<Transaction>> Handle(GetAllTransactionByUserPagedQuery request, CancellationToken cancellationToken) =>
            await _transactionRepository.GetByUserPagedAsync(request.UserId, request.PaginationOpt);
    }
}
