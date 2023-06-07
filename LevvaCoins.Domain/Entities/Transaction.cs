using LevvaCoins.Domain.Enums;
using LevvaCoins.Domain.Validation;

namespace LevvaCoins.Domain.Entities
{
    public sealed class Transaction
    {
        public Guid? Id { get; }
        public DateTime CreatedAt { get; }
        public string Description { get; private set; }
        public double Amount { get; private set; }
        public TransactionTypeEnum Type { get; private set; }
        public Guid CategoryId { get; private set; }
        public Guid UserId { get; private set; }
        public User? User { get; set; }
        public Category? Category { get; set; }

        public Transaction(string description, double amount, TransactionTypeEnum type, Guid categoryId, Guid userId , Guid? id = null)
        {
            Validate(description, amount, type, categoryId, userId);
            Id = id ?? Guid.NewGuid();
            Description = description;
            Amount = amount;
            Type = (TransactionTypeEnum) type;
            CategoryId = categoryId;
            UserId = userId;
        }
        public void Update(string description, double amount, TransactionTypeEnum type, Guid categoryId)
        {
            Validate(description,amount, type, categoryId);
            Description = description;
            Amount = amount;
            Type = type;
            CategoryId = categoryId;
        }
        private void Validate(string description, double amount, TransactionTypeEnum type, Guid categoryId, Guid userId)
        {
            Validate(description, amount, type, categoryId);
            DomainExceptionValidation.When(
                userId == Guid.Empty || string.IsNullOrWhiteSpace(userId.ToString()),"Informe uma usuario valido"
            );
        }
        private void Validate(string description, double amount, TransactionTypeEnum type, Guid categoryId)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(description), "Descrição não pode ser vazia");
            DomainExceptionValidation.When(amount < 0, "Valor não pode ser negativo");
            var transactionType = (int)type;
            DomainExceptionValidation.When(transactionType != 0 && transactionType != 1, "Informe um tipo valido de transação");
            DomainExceptionValidation.When(
                categoryId == Guid.Empty || string.IsNullOrWhiteSpace(categoryId.ToString()), "Informe uma categoria valida"
            );
        }
    }
}
