using LevvaCoins.Application.UseCases.Categories.Common;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Enums;

namespace LevvaCoins.Application.UseCases.Transactions.Common;

public class TransactionDetailsModelOutput
{
    public Guid Id { get; set; }
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public TransactionType Type { get; set; }
    public DateTime CreatedAt { get; set; }
    public CategoryModelOutput? Category { get; set; }

    public TransactionDetailsModelOutput(Guid id, string? description, decimal amount, TransactionType type, DateTime createdAt, CategoryModelOutput? category)
    {
        Id = id;
        Description = description;
        Amount = amount;
        Type = type;
        CreatedAt = createdAt;
        Category = category;
    }

    public static TransactionDetailsModelOutput FromDomain(Transaction transaction)
    {
        return new(
                transaction.Id,
                transaction.Description,
                transaction.Amount,
                transaction.Type,
                transaction.CreatedAt,
                CategoryModelOutput.FromDomain(transaction.Category!)
            );
    }
    public static IEnumerable<TransactionDetailsModelOutput> FromDomain(IEnumerable<Transaction> transactions) =>
        transactions.Select(FromDomain);
}