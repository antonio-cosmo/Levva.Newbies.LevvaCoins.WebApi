using System.Diagnostics.Contracts;
using LevvaCoins.Domain.Enums;
using LevvaCoins.Domain.Shared.Entities;
using LevvaCoins.Domain.Shared.Validations;
using LevvaCoins.Domain.ValueObjects;

namespace LevvaCoins.Domain.Entities
{
    public sealed class Transaction:Entity
    {
        private const int MIN_AMOUNT_VALUE = 0;
        public Description Description { get; private set; }
        public decimal Amount { get; private set; }
        public TransactionType Type { get; private set; }
        public Guid CategoryId { get; private set; }
        public Guid UserId { get; }
        public DateTime CreatedAt { get; }
        public User? User { get; set; }
        public Category? Category { get; set; }

        private Transaction() { }
        public Transaction(Description description, decimal amount, TransactionType type, Guid categoryId, Guid userId)
        {
            Description = description;
            Amount = amount;
            Type = type;
            CategoryId = categoryId;
            UserId = userId;

            if (Type != TransactionType.Income && Type != TransactionType.Outcome)
            {
                AddNotification(nameof(Type), "type different than expected");
            }

            AddNotifications(
                    Description,
                    new ValidationRule().Requires().GuidIsNotEmpty(UserId, nameof(UserId), "should  not be empty"),
                    new ValidationRule().Requires().GuidIsNotEmpty(CategoryId, nameof(CategoryId), "should  not be empty"),
                    new ValidationRule().Requires().HasGreaterThan(Amount, MIN_AMOUNT_VALUE, nameof(Amount), $"should have value more than {MIN_AMOUNT_VALUE}")

                );
        }
        public void ChangeDescription(Description description)
        {
            Description = description;
            AddNotifications(
                   Description
               );
        }
        public void ChangeAmount(decimal amount)
        {
            Amount = amount;
            AddNotifications(
                   new ValidationRule().Requires().
                   HasGreaterThan(Amount, MIN_AMOUNT_VALUE, nameof(Amount), $"should have value more than {MIN_AMOUNT_VALUE}")
               );
        }
        public void ChangeType(TransactionType type)
        {
            Type = type;

            if (Type != TransactionType.Income && Type != TransactionType.Outcome)
            {
                AddNotification(nameof(Type), "type different than expected");
            }
        }
        public void ChangeCategory(Guid categoryId)
        {
            CategoryId = categoryId;
            AddNotifications(
                   new ValidationRule().Requires().
                   GuidIsNotEmpty(CategoryId, nameof(CategoryId), "should  not be empty")
               );
        }
    }
}
