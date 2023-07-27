using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Enums;

namespace LevvaCoins.Application.UseCases.Transactions.Common
{
    public class TransactionModelOutput
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }

        public TransactionModelOutput(Guid id, string? description, decimal amount, TransactionType type, Guid categoryId, Guid userId, DateTime createdAt)
        {
            Id = id;
            Description = description;
            Amount = amount;
            Type = type;
            CategoryId = categoryId;
            UserId = userId;
            CreatedAt = createdAt;
        }

        public static TransactionModelOutput FromDomain(Transaction transaction)
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
        public static IEnumerable<TransactionModelOutput> FromDomain(IEnumerable<Transaction> transactions) =>
            transactions.Select(FromDomain);
    }
}
