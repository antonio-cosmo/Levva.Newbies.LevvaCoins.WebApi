using LevvaCoins.Domain.Enums;
using LevvaCoins.Domain.Validation;

namespace LevvaCoins.Domain.Entities
{
    public sealed class Transaction:Entity
    {
        public DateTime CreatedAt { get; }
        public string Description { get; private set; }
        public double Amount { get; private set; }
        public TransactionTypeEnum Type { get; private set; }
        public Guid CategoryId { get; private set; }
        public Guid UserId { get; }
        public User? User { get; set; }
        public Category? Category { get; set; }

        public Transaction(string description, double amount, TransactionTypeEnum type, Guid categoryId, Guid userId)
        {
            Description = description;
            Amount = amount;
            Type = type;
            CategoryId = categoryId;
            UserId = userId;
        }
        public void Update(string description, double amount, TransactionTypeEnum type, Guid categoryId)
        {
            Description = description;
            Amount = amount;
            Type = type;
            CategoryId = categoryId;
        }

        public override void Validate()
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(Description), "Descrição não pode ser vazia");
            DomainExceptionValidation.When(Amount < 0, "Valor não pode ser negativo");
            var transactionType = (int) Type;
            DomainExceptionValidation.When(transactionType != 0 && transactionType != 1, "Informe um tipo valido de transação");
            DomainExceptionValidation.When(
                CategoryId == Guid.Empty || string.IsNullOrWhiteSpace(CategoryId.ToString()), "Informe uma categoria valida"
            );
            DomainExceptionValidation.When(
                UserId == Guid.Empty || string.IsNullOrWhiteSpace(UserId.ToString()), "Informe uma usuario valido"
            );

        }
    }
}
