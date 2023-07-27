using LevvaCoins.Domain.Enums;

namespace LevvaCoins.Api.ApiModels.Transaction;

public class CreateTransactionApiInput
{
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public TransactionType Type { get; set; }
    public Guid CategoryId { get; set; }

    public CreateTransactionApiInput(string description, decimal amount, TransactionType type, Guid categoryId)
    {
        Description = description;
        Amount = amount;
        Type = type;
        CategoryId = categoryId;
    }
}
