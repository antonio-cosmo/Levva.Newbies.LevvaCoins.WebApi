using LevvaCoins.Application.UseCases.Transactions.Common;
using MediatR;

namespace LevvaCoins.Application.UseCases.Transactions.SearchTransactionByDescription;

public interface ISearchTransactionsByDescription : IRequestHandler<SearchTransactionsByDescriptionInput, IEnumerable<TransactionDetailsModelOutput>>
{
}
