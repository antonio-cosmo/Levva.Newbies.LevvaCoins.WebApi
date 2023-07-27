using LevvaCoins.Application.UseCases.Transactions.Common;
using LevvaCoins.Domain.SeedWork;

namespace LevvaCoins.Application.UseCases.Transactions.SearchTransactionByDescription;

public class SearchTransactionsByDescription : ISearchTransactionsByDescription
{
    private readonly IUnitOfWork _unitOfWork;

    public SearchTransactionsByDescription(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<TransactionDetailsModelOutput>> Handle(SearchTransactionsByDescriptionInput request, CancellationToken cancellationToken)
    {
        var transactions = await _unitOfWork.TransactionRepository.SearchByDescriptionAsync(request.UserId, request.Text, cancellationToken);
        return TransactionDetailsModelOutput.FromDomain(transactions);
    }
}
