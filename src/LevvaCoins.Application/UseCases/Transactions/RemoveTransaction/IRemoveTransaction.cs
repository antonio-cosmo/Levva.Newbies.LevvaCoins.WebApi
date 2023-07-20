using LevvaCoins.Application.Exceptions;
using LevvaCoins.Domain.Repositories;
using MediatR;

namespace LevvaCoins.Application.UseCases.Transactions.RemoveTransaction;

public interface IRemoveTransaction : IRequestHandler<RemoveTransactionInput>
{
}
