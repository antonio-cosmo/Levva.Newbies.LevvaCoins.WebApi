using LevvaCoins.Application.UseCases.Transactions.Common;
using LevvaCoins.Domain.SeedWork;

namespace LevvaCoins.Application.UseCases.Transactions.GetAllTransactions
{
    public class GetAllTransactionsHandler : IGetAllTransactionsHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllTransactionsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<TransactionDetailsModelResponse>> Handle(GetAllTransactions request, CancellationToken cancellationToken)
        {
            var transactions = await _unitOfWork.TransactionRepository.GetAllByUserAsync(request.UserId, cancellationToken);
            return TransactionDetailsModelResponse.FromDomain(transactions);
        }

    }
}
