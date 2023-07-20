using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Enums;

namespace LevvaCoins.Application.UseCases.Transactions.Common
{
    public class TransactionOutput
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public ETransactionType Type { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }

        public TransactionOutput(Guid id, string? description, decimal amount, ETransactionType type, Guid categoryId, Guid userId, DateTime createdAt)
        {
            Id = id;
            Description = description;
            Amount = amount;
            Type = type;
            CategoryId = categoryId;
            UserId = userId;
            CreatedAt = createdAt;
        }

        public static TransactionOutput FromModel(Transaction transaction)
        {
            return new(
                transaction.Id,
                transaction.Description,
                transaction.Amount,
                transaction.Type,
                transaction.CategoryId,
                transaction.UserId,
                transaction.CreatedAt
            );
        }
        public static IEnumerable<TransactionOutput> FromModel(IEnumerable<Transaction> transactions) =>
            transactions.Select(FromModel);
    }
}
