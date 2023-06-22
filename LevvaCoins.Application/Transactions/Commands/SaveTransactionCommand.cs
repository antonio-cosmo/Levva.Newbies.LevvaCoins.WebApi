using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Enums;
using MediatR;

namespace LevvaCoins.Application.Transactions.Commands
{
    public class SaveTransactionCommand: IRequest<Transaction>
    {
        public Guid UserId { get; }
        public string Description { get;}
        public double Amount { get; }
        public TransactionType Type { get; }
        public Guid CategoryId { get; }

        public SaveTransactionCommand(Guid userId, string description, double amount, TransactionType type, Guid categoryId)
        {
            Description = description;
            Amount = amount;
            Type = type;
            CategoryId = categoryId;
            UserId = userId;
        }
    }
}
