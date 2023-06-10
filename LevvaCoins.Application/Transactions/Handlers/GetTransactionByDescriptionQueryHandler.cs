using LevvaCoins.Application.Transactions.Queries;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Interfaces.Repositories;
using MediatR;

namespace LevvaCoins.Application.Transactions.Handlers
{
    public class GetTransactionByDescriptionQueryHandler : IRequestHandler<GetTransactionByDescriptionQuery, IEnumerable<Transaction>>
    {
        readonly ITransactionRepository _transactionRepository;

        public GetTransactionByDescriptionQueryHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<IEnumerable<Transaction>> Handle(GetTransactionByDescriptionQuery request, CancellationToken cancellationToken)
        {
            return await _transactionRepository.SearchByDescriptionAndIncludeCategoryAsync(request.UserId, request.Text);

        }
    }
}
