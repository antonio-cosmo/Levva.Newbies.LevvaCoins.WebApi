using LevvaCoins.Application.UseCases.Transactions.Common;
using LevvaCoins.Domain.Enums;
using MediatR;

namespace LevvaCoins.Application.UseCases.Transactions.CreateTransaction;

public class CreateTransaction : IRequest<TransactionDetailsModelResponse>
{
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public TransactionType Type { get; set; }
    public Guid CategoryId { get; set; }
    public Guid UserId { get; set; }

    public CreateTransaction(string description, decimal amount, TransactionType type, Guid categoryId, Guid userId)
    {
        Description = description;
        Amount = amount;
        Type = type;
        CategoryId = categoryId;
        UserId = userId;
    }
}
