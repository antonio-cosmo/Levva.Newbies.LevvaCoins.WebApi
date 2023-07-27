using LevvaCoins.Domain.SeedWork;
using LevvaCoins.Domain.Validation;

namespace LevvaCoins.Domain.Entities
{
    public sealed class Category : Entity
    {
        private const int MIN_DESCRIPTION_LENGTH = 3;
        public string Description { get; private set; }
        public IList<Transaction> Transactions { get; set; }
        public Category(string description)
        {
            Description = description;
            Transactions = new List<Transaction>();
            Validate();
        }
        public void ChangeDescription(string description)
        {
            Description = description;
            Validate();
        }
        private void Validate()
        {
            DomainValidation.HasLessThan(Description, MIN_DESCRIPTION_LENGTH, nameof(Description));
            DomainValidation.IsNull(Description, nameof(Description));
        }
    }
}
