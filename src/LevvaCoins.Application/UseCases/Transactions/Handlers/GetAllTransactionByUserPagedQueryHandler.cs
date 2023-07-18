using AutoMapper;
using LevvaCoins.Application.UseCases.Transactions.Queries;
using LevvaCoins.Domain.Common;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Repositories;
using MediatR;

namespace LevvaCoins.Application.UseCases.Transactions.Handlers
{
    public class GetAllTransactionByUserPagedQueryHandler : IRequestHandler<GetAllTransactionByUserPagedQuery, PagedResult<Transaction>>
    {
        readonly ITransactionRepository _transactionRepository;

        public GetAllTransactionByUserPagedQueryHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<PagedResult<Transaction>> Handle(GetAllTransactionByUserPagedQuery request, CancellationToken cancellationToken) =>
            await _transactionRepository.GetByUserPagedAsync(request.UserId, request.PaginationOpt, cancellationToken);
    }
}
