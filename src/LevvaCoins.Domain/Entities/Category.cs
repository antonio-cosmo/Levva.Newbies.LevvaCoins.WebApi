using LevvaCoins.Domain.SeedWork;

namespace LevvaCoins.Domain.Entities;

public sealed class Category : Entity
{
    private const int MIN_DESCRIPTION_LENGTH = 4;

    public Category(string description)
    {
        Description = description.ToUpper();
        Transactions = new List<Transaction>();
        Validate();
    }

    public string Description { get; private set; }
    public IList<Transaction> Transactions { get; set; }

    public void ChangeDescription(string description)
    {
        Description = description.ToUpper();
        Validate();
    }

    protected override void Validate()
    {
        if (Description.Length < MIN_DESCRIPTION_LENGTH)
            AddNotification(nameof(Description), $"should be greater than {MIN_DESCRIPTION_LENGTH}");

        if (string.IsNullOrWhiteSpace(Description))
            AddNotification(nameof(Description), "should not be null");
    }
}