using LevvaCoins.Domain.Validation;

namespace LevvaCoins.Domain.Entities
{
    public sealed class Category: Entity
    {

        public string Description { get; private set; }
        public IList<Transaction>? Transactions { get; set; }

        public Category(string description) {
            Description = description.ToLower();
        }

        public void Update(string description)
        {
            Description = description;
        }

        public override void Validate()
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(Description), "Descrição não pode ser vazia");
            DomainExceptionValidation.When(Description.Length < 3, "Descrição não pode ser vazia");
        }
    }
}
