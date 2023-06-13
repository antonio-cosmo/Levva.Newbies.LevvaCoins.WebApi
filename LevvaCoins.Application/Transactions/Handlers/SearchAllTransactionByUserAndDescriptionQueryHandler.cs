using LevvaCoins.Application.Transactions.Queries;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Interfaces.Repositories;
using MediatR;

namespace LevvaCoins.Application.Transactions.Handlers
{
    public class SearchAllTransactionByUserAndDescriptionQueryHandler : IRequestHandler<SearchAllTransactionByUserAndDescriptionQuery, IEnumerable<Transaction>>
    {
        readonly ITransactionRepository _transactionRepository;

        public SearchAllTransactionByUserAndDescriptionQueryHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<IEnumerable<Transaction>> Handle(SearchAllTransactionByUserAndDescriptionQuery request, CancellationToken cancellationToken)
        {
            return await _transactionRepository.SearchByDescriptionAsync(request.UserId, request.Text);

        }
    }
}
