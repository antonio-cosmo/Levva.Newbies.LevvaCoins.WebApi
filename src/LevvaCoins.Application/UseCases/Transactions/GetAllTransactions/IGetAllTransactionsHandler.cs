using LevvaCoins.Application.UseCases.Transactions.Common;
using MediatR;

namespace LevvaCoins.Application.UseCases.Transactions.GetAllTransactions;

public interface IGetAllTransactionsHandler : IRequestHandler<GetAllTransactions, IEnumerable<TransactionDetailsModelResponse>>
{
}
