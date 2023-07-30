using LevvaCoins.Application.UseCases.Transactions.Common;
using MediatR;

namespace LevvaCoins.Application.UseCases.Transactions.GetAllTransactions;

public class GetAllTransactions : IRequest<IEnumerable<TransactionDetailsModelResponse>>
{
    public Guid UserId { get; set; }

    public GetAllTransactions(Guid userId)
    {
        UserId = userId;
    }
}
