using LevvaCoins.Application.UseCases.Transactions.Queries;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Repositories;
using MediatR;

namespace LevvaCoins.Application.UseCases.Transactions.Handlers
{
    public class SearchAllTransactionByUserAndDescriptionQueryHandler : IRequestHandler<SearchAllTransactionByUserAndDescriptionQuery, IEnumerable<Transaction>>
    {
        readonly ITransactionRepository _transactionRepository;

        public SearchAllTransactionByUserAndDescriptionQueryHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<IEnumerable<Transaction>> Handle(SearchAllTransactionByUserAndDescriptionQuery request, CancellationToken cancellationToken) =>
            await _transactionRepository.SearchByDescriptionAsync(request.UserId, request.Text, cancellationToken);
    }
}
