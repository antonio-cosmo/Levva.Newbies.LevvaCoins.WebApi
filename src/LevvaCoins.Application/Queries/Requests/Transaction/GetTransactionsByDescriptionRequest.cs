using LevvaCoins.Application.Responses;
using MediatR;

namespace LevvaCoins.Application.Queries.Requests.Transaction;

public class GetTransactionsByDescriptionRequest : IRequest<IEnumerable<TransactionDetailsModelResponse>>
{
    public GetTransactionsByDescriptionRequest(Guid userId, string text)
    {
        UserId = userId;
        Text = text;
    }

    public Guid UserId { get; set; }
    public string Text { get; set; }
}