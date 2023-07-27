using LevvaCoins.Application.UseCases.Transactions.Common;
using LevvaCoins.Domain.SeedWork;

namespace LevvaCoins.Application.UseCases.Transactions.GetAllTransactions
{
    public class GetAllTransactions : IGetAllTransactions
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllTransactions(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<TransactionDetailsModelOutput>> Handle(GetAllTransactionsInput request, CancellationToken cancellationToken)
        {
            var transactions = await _unitOfWork.TransactionRepository.GetAllByUserAsync(request.UserId, cancellationToken);
            return TransactionDetailsModelOutput.FromDomain(transactions);
        }

    }
}
