using LevvaCoins.Domain.Enums;
using MediatR;

namespace LevvaCoins.Application.UseCases.Transactions.UpdateTransaction;

public class UpdateTransaction : IRequest
{
    public Guid Id { get; }
    public string Description { get; }
    public decimal Amount { get; }
    public TransactionType Type { get; }
    public Guid CategoryId { get; }

    public UpdateTransaction(Guid id, string description, decimal amount, TransactionType type, Guid categoryId)
    {
        Id = id;
        Description = description;
        Amount = amount;
        Type = type;
        CategoryId = categoryId;
    }
}
