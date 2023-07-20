using LevvaCoins.Application.UseCases.Transactions.Common;
using LevvaCoins.Domain.Repositories;

namespace LevvaCoins.Application.UseCases.Transactions.SearchTransactionByDescription
{
    public class SearchTransactionsByDescription : ISearchTransactionsByDescription
    {
        readonly ITransactionRepository _transactionRepository;

        public SearchTransactionsByDescription(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<IEnumerable<TransactionDetailsOutput>> Handle(SearchTransactionsByDescriptionInput request, CancellationToken cancellationToken)
        {
            var transactions = await _transactionRepository.SearchByDescriptionAsync(request.UserId, request.Text, cancellationToken);
            return TransactionDetailsOutput.FromModel(transactions);
        }
    }
}
