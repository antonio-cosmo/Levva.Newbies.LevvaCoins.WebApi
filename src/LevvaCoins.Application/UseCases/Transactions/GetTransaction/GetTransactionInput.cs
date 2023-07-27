using LevvaCoins.Application.UseCases.Transactions.Common;
using MediatR;

namespace LevvaCoins.Application.UseCases.Transactions.GetTransaction;

public class GetTransactionInput : IRequest<TransactionModelOutput>
{
    public Guid Id { get; set; }

    public GetTransactionInput(Guid id)
    {
        Id = id;
    }
}
