using LevvaCoins.Application.Responses;
using MediatR;

namespace LevvaCoins.Application.Queries.Requests.Transaction;

public class GetTransactionRequest : IRequest<TransactionModelResponse>
{
    public GetTransactionRequest(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}