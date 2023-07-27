using LevvaCoins.Domain.Enums;
using LevvaCoins.Domain.Exceptions;
using LevvaCoins.Domain.SeedWork;
using LevvaCoins.Domain.Validation;

namespace LevvaCoins.Domain.Entities
{
    public sealed class Transaction : Entity
    {
        private const int MIN_AMOUNT_VALUE = 0;
        private const int MIN_DESCRIPTION_LENGTH = 3;
        public string Description { get; private set; }
        public decimal Amount { get; private set; }
        public TransactionType Type { get; private set; }
        public Guid CategoryId { get; private set; }
        public Guid UserId { get; }
        public DateTime CreatedAt { get; }
        public User? User { get; set; }
        public Category? Category { get; set; }

        public Transaction(string description, decimal amount, TransactionType type, Guid categoryId, Guid userId)
        {
            Description = description;
            Amount = amount;
            Type = type;
            CategoryId = categoryId;
            UserId = userId;
            CreatedAt = DateTime.Now;
            Validate();
        }
        public void ChangeDescription(string description)
        {
            Description = description;
            Validate();
        }
        public void ChangeAmount(decimal amount)
        {
            Amount = amount;
            Validate();
        }
        public void ChangeType(TransactionType type)
        {
            Type = type;
            Validate();
        }
        public void ChangeCategory(Guid categoryId)
        {
            CategoryId = categoryId;
            Validate();
        }
        private void Validate()
        {
            DomainValidation.GuidIsNotEmpty(UserId, nameof(UserId));
            DomainValidation.GuidIsNotEmpty(CategoryId, nameof(CategoryId));
            DomainValidation.HasLessThan(Amount, MIN_AMOUNT_VALUE ,nameof(Amount));
            DomainValidation.HasLessThan(Description, MIN_DESCRIPTION_LENGTH, nameof(Description));
            DomainValidation.IsNull(Description, nameof(Description));
            if (Type != TransactionType.Income && Type != TransactionType.Outcome)
                throw new EntityValidationException($"{nameof(Type)} type different than expected");
        }
    }
}
