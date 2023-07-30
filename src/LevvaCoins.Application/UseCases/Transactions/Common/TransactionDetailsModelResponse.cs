using LevvaCoins.Application.Services.Dtos.Category;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Enums;

namespace LevvaCoins.Application.UseCases.Transactions.Common;

public class TransactionDetailsModelResponse
{
    public Guid Id { get; set; }
    public string? Description { get; set; }
    public decimal Amount { get; set; }
    public TransactionType Type { get; set; }
    public DateTime CreatedAt { get; set; }
    public CategoryModelResponse? Category { get; set; }

    public TransactionDetailsModelResponse(Guid id, string? description, decimal amount, TransactionType type, DateTime createdAt, CategoryModelResponse? category)
    {
        Id = id;
        Description = description;
        Amount = amount;
        Type = type;
        CreatedAt = createdAt;
        Category = category;
    }

    public static TransactionDetailsModelResponse FromDomain(Transaction transaction)
    {
        return new(
                transaction.Id,
                transaction.Description,
                transaction.Amount,
                transaction.Type,
                transaction.CreatedAt,
                CategoryModelResponse.FromDomain(transaction.Category!)
            );
    }
    public static IEnumerable<TransactionDetailsModelResponse> FromDomain(IEnumerable<Transaction> transactions) =>
        transactions.Select(FromDomain);
}