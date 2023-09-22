using LevvaCoins.Domain.Enums;
using LevvaCoins.Domain.Exceptions;
using LevvaCoins.Domain.SeedWork;

namespace LevvaCoins.Domain.Entities;

public sealed class Transaction : Entity
{
    private const int MIN_AMOUNT_VALUE = 0;
    private const int MIN_DESCRIPTION_LENGTH = 3;

    public Transaction(string description, decimal amount, TransactionType type, Guid categoryId, Guid userId)
    {
        Description = description;
        Amount = amount;
        Type = type;
        CategoryId = categoryId;
        UserId = userId;
        CreatedAt = DateTime.Now;
        Validate();
    }

    public string Description { get; private set; }
    public decimal Amount { get; private set; }
    public TransactionType Type { get; private set; }
    public Guid CategoryId { get; private set; }
    public Guid UserId { get; }
    public DateTime CreatedAt { get; }
    public User? User { get; set; }
    public Category? Category { get; set; }

    public void ChangeDescription(string description)
    {
        Description = description;
        Validate();
    }

    public void ChangeAmount(decimal amount)
    {
        Amount = amount;
        Validate();
    }

    public void ChangeType(TransactionType type)
    {
        Type = type;
        Validate();
    }

    public void ChangeCategory(Guid categoryId)
    {
        CategoryId = categoryId;
        Validate();
    }

    protected override void Validate()
    {
        if (CategoryId == Guid.Empty)
            AddNotification(nameof(CategoryId), "should  not be empty");
        if (UserId == Guid.Empty)
            AddNotification(nameof(UserId), "should  not be empty");
        if (Amount < MIN_AMOUNT_VALUE)
            AddNotification(nameof(Amount), $"should be greater than {MIN_AMOUNT_VALUE}");
        if (Description.Length < MIN_DESCRIPTION_LENGTH)
            AddNotification(nameof(Description), $"should be greater than {MIN_DESCRIPTION_LENGTH}");
        if (string.IsNullOrWhiteSpace(Description))
            AddNotification(nameof(Description), "should not be null");
        if (Type != TransactionType.Income && Type != TransactionType.Outcome)
            throw new EntityValidationException($"{nameof(Type)} type different than expected");
    }
}