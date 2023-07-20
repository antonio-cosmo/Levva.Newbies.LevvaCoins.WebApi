using LevvaCoins.Application.UseCases.Transactions.Common;
using LevvaCoins.Domain.Repositories;

namespace LevvaCoins.Application.UseCases.Transactions.GetAllTransactions
{
    public class GetAllTransactions : IGetAllTransactions
    {
        readonly ITransactionRepository _transactionRepository;
        public GetAllTransactions(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public async Task<IEnumerable<TransactionDetailsOutput>> Handle(GetAllTransactionsInput request, CancellationToken cancellationToken)
        {
            var transactions = await _transactionRepository.GetAllByUserAsync(request.UserId, cancellationToken);
            return TransactionDetailsOutput.FromModel(transactions);
        }

    }
}
