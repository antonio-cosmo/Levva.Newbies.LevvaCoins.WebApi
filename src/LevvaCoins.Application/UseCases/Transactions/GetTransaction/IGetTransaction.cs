using LevvaCoins.Application.UseCases.Transactions.Common;
using MediatR;

namespace LevvaCoins.Application.UseCases.Transactions.GetTransaction;

public interface IGetTransaction : IRequestHandler<GetTransactionInput, TransactionModelOutput>
{
}
