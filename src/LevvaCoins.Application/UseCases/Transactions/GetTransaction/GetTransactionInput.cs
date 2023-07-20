using LevvaCoins.Application.UseCases.Transactions.Common;
using LevvaCoins.Domain.Entities;
using MediatR;

namespace LevvaCoins.Application.UseCases.Transactions.GetTransaction;

public class GetTransactionInput : IRequest<TransactionOutput>
{
    public Guid Id { get; set; }

    public GetTransactionInput(Guid id)
    {
        Id = id;
    }
}
