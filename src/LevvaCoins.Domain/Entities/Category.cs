using LevvaCoins.Domain.SeedWork;
using LevvaCoins.Domain.Validation;
using LevvaCoins.Domain.ValueObjects;

namespace LevvaCoins.Domain.Entities
{
    public sealed class Category : Entity
    {
        public Description Description { get; private set; }
        public IList<Transaction>? Transactions { get; set; }
        public Category(Description description)
        {
            Description = description;
            Validate();
        }
        public void ChangeDescription(Description description)
        {
            Description = description;
            Validate();
        }
        private void Validate()
        {
            DomainValidation.IsNull(Description, nameof(Description));
        }

        // For EF
        private Category() { }
    }
}
