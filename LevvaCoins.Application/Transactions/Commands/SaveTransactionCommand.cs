using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Enums;
using MediatR;

namespace LevvaCoins.Application.Transactions.Commands
{
    public class SaveTransactionCommand: IRequest<Transaction>
    {
        public string Description { get; set; } = string.Empty;
        public double Amount { get; set; }
        public TransactionTypeEnum Type { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }

        public SaveTransactionCommand(string description, double amount, TransactionTypeEnum type, Guid categoryId, Guid userId)
        {
            Description = description;
            Amount = amount;
            Type = type;
            CategoryId = categoryId;
            UserId = userId;
        }
    }
}
