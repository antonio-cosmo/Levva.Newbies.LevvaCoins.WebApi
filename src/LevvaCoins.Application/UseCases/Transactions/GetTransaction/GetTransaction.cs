using LevvaCoins.Application.UseCases.Transactions.Common;
using MediatR;

namespace LevvaCoins.Application.UseCases.Transactions.GetTransaction;

public class GetTransaction : IRequest<TransactionModelResponse>
{
    public Guid Id { get; set; }

    public GetTransaction(Guid id)
    {
        Id = id;
    }
}
