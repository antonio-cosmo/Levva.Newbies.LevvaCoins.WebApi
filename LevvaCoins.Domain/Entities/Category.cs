using LevvaCoins.Domain.Validation;

namespace LevvaCoins.Domain.Entities
{
    public sealed class Category: Entity
    {

        public string Description { get; private set; }
        public IList<Transaction>? Transactions { get; set; }

        public Category(string description, Guid? id = null) {
            Validate(description);

            Id = id ?? Guid.NewGuid();
            Description = description.ToLower();
        }

        public void Update(string description)
        {
            Validate(description);
            Description = description;
        }
        
        private void Validate(string description)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(description), "Descrição não pode ser vazia");
            DomainExceptionValidation.When(description.Length < 3, "Descrição não pode ser vazia");
        }
    }
}
