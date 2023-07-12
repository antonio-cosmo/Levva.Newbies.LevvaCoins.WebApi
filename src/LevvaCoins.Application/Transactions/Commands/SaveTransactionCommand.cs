using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Enums;
using MediatR;

namespace LevvaCoins.Application.Transactions.Commands
{
    public class SaveTransactionCommand: IRequest<Transaction>
    {
        public Guid UserId { get; }
        public string Description { get;}
        public decimal Amount { get; }
        public ETransactionType Type { get; }
        public Guid CategoryId { get; }

        public SaveTransactionCommand(Guid userId, string description, decimal amount, ETransactionType type, Guid categoryId)
        {
            Description = description;
            Amount = amount;
            Type = type;
            CategoryId = categoryId;
            UserId = userId;
        }
    }
}
