using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Enums;
using MediatR;

namespace LevvaCoins.Application.Transactions.Commands
{
    public class SaveTransactionCommand: IRequest<Transaction>
    {
        public Guid UserId { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public TransactionTypeEnum Type { get; set; }
        public Guid CategoryId { get; set; }

        public SaveTransactionCommand(Guid userId, string description, double amount, TransactionTypeEnum type, Guid categoryId)
        {
            Description = description;
            Amount = amount;
            Type = type;
            CategoryId = categoryId;
            UserId = userId;
        }
    }
}
