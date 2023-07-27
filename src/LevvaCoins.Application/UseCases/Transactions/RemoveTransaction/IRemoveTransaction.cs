using MediatR;

namespace LevvaCoins.Application.UseCases.Transactions.RemoveTransaction;

public interface IRemoveTransaction : IRequestHandler<RemoveTransactionInput>
{
}
