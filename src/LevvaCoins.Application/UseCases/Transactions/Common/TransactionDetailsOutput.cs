using LevvaCoins.Application.UseCases.Categories.Common;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Enums;

namespace LevvaCoins.Application.UseCases.Transactions.Common;

public class TransactionDetailsOutput
{
    public Guid Id { get; set; }
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public ETransactionType Type { get; set; }
    public DateTime CreatedAt { get; set; }
    public CategoryOutput? Category { get; set; }

    public TransactionDetailsOutput(Guid id, string? description, decimal amount, ETransactionType type, DateTime createdAt, CategoryOutput? category)
    {
        Id = id;
        Description = description;
        Amount = amount;
        Type = type;
        CreatedAt = createdAt;
        Category = category;
    }

    public static TransactionDetailsOutput FromModel(Transaction transaction)
    {
        return new(
                transaction.Id,
                transaction.Description,
                transaction.Amount,
                transaction.Type,
                transaction.CreatedAt,
                CategoryOutput.FromDomain(transaction.Category!)
            );
    }
    public static IEnumerable<TransactionDetailsOutput> FromModel(IEnumerable<Transaction> transactions) =>
        transactions.Select(FromModel);
}