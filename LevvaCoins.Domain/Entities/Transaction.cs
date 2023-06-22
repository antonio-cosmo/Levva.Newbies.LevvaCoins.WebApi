using LevvaCoins.Domain.Enums;

namespace LevvaCoins.Domain.Entities
{
    public sealed class Transaction:Entity
    {
        public string Description { get; private set; }
        public double Amount { get; private set; }
        public TransactionType Type { get; private set; }
        public Guid CategoryId { get; private set; }
        public Guid UserId { get; }
        public DateTime CreatedAt { get; }
        public User? User { get; set; }
        public Category? Category { get; set; }

        public Transaction(string description, double amount, TransactionType type, Guid categoryId, Guid userId)
        {
            Description = description;
            Amount = amount;
            Type = type;
            CategoryId = categoryId;
            UserId = userId;
        }
        public void Update(string description, double amount, TransactionType type, Guid categoryId)
        {
            Description = description;
            Amount = amount;
            Type = type;
            CategoryId = categoryId;
        }

        public override bool IsValid()
        {
            if(string.IsNullOrWhiteSpace(Description))
                return false;
            if(Amount < 0)
                return false;
            if(Type != TransactionType.Income && Type != TransactionType.Outcome)
                return false;
            if (CategoryId == Guid.Empty || string.IsNullOrWhiteSpace(CategoryId.ToString()))
                return false;
            if (UserId == Guid.Empty || string.IsNullOrWhiteSpace(UserId.ToString()))
                return false;

            return true;
        }
    }
}
