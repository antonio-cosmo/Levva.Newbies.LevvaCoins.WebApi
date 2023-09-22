using MediatR;

namespace LevvaCoins.Application.Commands.Requests.Transaction;

public class RemoveTransactionRequest : IRequest
{
    public RemoveTransactionRequest(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}