using LevvaCoins.Application.UseCases.Transactions.Common;
using LevvaCoins.Domain.Enums;
using MediatR;

namespace LevvaCoins.Application.UseCases.Transactions.CreateTransaction;

public class CreateTransactionInput : IRequest<TransactionDetailsOutput>
{
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public ETransactionType Type { get; set; }
    public Guid CategoryId { get; set; }
    public Guid UserId { get; set; }

    public CreateTransactionInput(string description, decimal amount, ETransactionType type, Guid categoryId, Guid userId)
    {
        Description = description;
        Amount = amount;
        Type = type;
        CategoryId = categoryId;
        UserId = userId;
    }
}
