using LevvaCoins.Domain.Enums;
using MediatR;

namespace LevvaCoins.Application.Commands.Requests.Transaction;

public class UpdateTransactionRequest : IRequest
{
    public UpdateTransactionRequest(Guid id, string description, decimal amount, TransactionType type, Guid categoryId)
    {
        Id = id;
        Description = description;
        Amount = amount;
        Type = type;
        CategoryId = categoryId;
    }

    public Guid Id { get; }
    public string Description { get; }
    public decimal Amount { get; }
    public TransactionType Type { get; }
    public Guid CategoryId { get; }
}