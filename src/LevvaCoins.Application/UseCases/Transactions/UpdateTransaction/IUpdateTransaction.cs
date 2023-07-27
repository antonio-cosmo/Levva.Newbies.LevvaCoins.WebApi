using MediatR;

namespace LevvaCoins.Application.UseCases.Transactions.UpdateTransaction;

public interface IUpdateTransaction : IRequestHandler<UpdateTransactionInput>
{
}
