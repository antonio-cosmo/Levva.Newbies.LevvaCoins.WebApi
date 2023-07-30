using LevvaCoins.Application.UseCases.Transactions.Common;
using LevvaCoins.Domain.SeedWork;

namespace LevvaCoins.Application.UseCases.Transactions.SearchTransactionByDescription;

public class SearchTransactionsByDescriptionHandler : ISearchTransactionsByDescriptionHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public SearchTransactionsByDescriptionHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<TransactionDetailsModelResponse>> Handle(SearchTransactionsByDescription request, CancellationToken cancellationToken)
    {
        var transactions = await _unitOfWork.TransactionRepository.SearchByDescriptionAsync(request.UserId, request.Text, cancellationToken);
        return TransactionDetailsModelResponse.FromDomain(transactions);
    }
}
