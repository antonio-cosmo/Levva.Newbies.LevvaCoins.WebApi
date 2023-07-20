using LevvaCoins.Domain.Enums;

namespace LevvaCoins.Api.ApiModel.Transaction;

public class UpdateTransactionApiInput
{
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public ETransactionType Type { get; set; }
    public Guid CategoryId { get; set; }

    public UpdateTransactionApiInput(string description, decimal amount, ETransactionType type, Guid categoryId)
    {
        Description = description;
        Amount = amount;
        Type = type;
        CategoryId = categoryId;
    }
}
