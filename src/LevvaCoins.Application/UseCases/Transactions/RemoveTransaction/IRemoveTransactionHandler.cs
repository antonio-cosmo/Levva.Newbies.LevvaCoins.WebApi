using MediatR;

namespace LevvaCoins.Application.UseCases.Transactions.RemoveTransaction;

public interface IRemoveTransactionHandler : IRequestHandler<RemoveTransaction>
{
}
