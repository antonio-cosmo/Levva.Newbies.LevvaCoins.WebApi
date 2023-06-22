namespace LevvaCoins.Domain.Entities
{
    public sealed class Category : Entity
    {
        private string _description = string.Empty;
        public string Description
        {
            get { return _description; }
            private set { _description = value.ToLower(); }
        }
        public IList<Transaction>? Transactions { get; set; }

        public Category(string description)
        {
            Description = description;
        }

        public void Update(string description)
        {
            Description = description;
        }

        public override bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Description) && Description.Length >= 3;
        }
    }
}
