using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Enums;

namespace LevvaCoins.Application.Responses;

public class TransactionDetailsModelResponse
{
    public TransactionDetailsModelResponse(Guid id, string? description, decimal amount, TransactionType type,
        DateTime createdAt, CategoryModelResponse? category)
    {
        Id = id;
        Description = description;
        Amount = amount;
        Type = type;
        CreatedAt = createdAt;
        Category = category;
    }

    public Guid Id { get; set; }
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public TransactionType Type { get; set; }
    public DateTime CreatedAt { get; set; }
    public CategoryModelResponse? Category { get; set; }

    public static TransactionDetailsModelResponse FromDomain(Transaction transaction)
    {
        return new TransactionDetailsModelResponse(
            transaction.Id,
            transaction.Description,
            transaction.Amount,
            transaction.Type,
            transaction.CreatedAt,
            CategoryModelResponse.FromDomain(transaction.Category!)
        );
    }

    public static IEnumerable<TransactionDetailsModelResponse> FromDomain(IEnumerable<Transaction> transactions)
    {
        return transactions.Select(FromDomain);
    }
}