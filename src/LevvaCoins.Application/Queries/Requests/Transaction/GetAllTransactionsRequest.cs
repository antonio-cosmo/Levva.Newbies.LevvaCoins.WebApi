using LevvaCoins.Application.Responses;
using MediatR;

namespace LevvaCoins.Application.Queries.Requests.Transaction;

public class GetAllTransactionsRequest : IRequest<IEnumerable<TransactionDetailsModelResponse>>
{
    public GetAllTransactionsRequest(Guid userId)
    {
        UserId = userId;
    }

    public Guid UserId { get; set; }
}