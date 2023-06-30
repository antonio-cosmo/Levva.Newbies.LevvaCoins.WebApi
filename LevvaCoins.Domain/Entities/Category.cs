using LevvaCoins.Domain.Shared.Entities;
using LevvaCoins.Domain.ValueObjects;

namespace LevvaCoins.Domain.Entities
{
    public sealed class Category : Entity
    {
        public Description Description { get; private set; }
        public IList<Transaction>? Transactions { get; set; }
        private Category() { }
        public Category(Description description)
        {
            Description = description;

            AddNotifications(Description);
        }
        public void ChangeDescription(Description description)
        {
            Description = description;
        }
    }
}
