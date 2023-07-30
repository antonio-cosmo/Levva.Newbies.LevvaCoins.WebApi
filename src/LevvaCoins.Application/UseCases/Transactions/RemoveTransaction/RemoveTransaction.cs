using MediatR;

namespace LevvaCoins.Application.UseCases.Transactions.RemoveTransaction;

public class RemoveTransaction : IRequest
{
    public Guid Id { get; set; }

    public RemoveTransaction(Guid id)
    {
        Id = id;
    }
}
