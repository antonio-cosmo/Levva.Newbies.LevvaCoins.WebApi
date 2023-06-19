using LevvaCoins.Domain.Enums;
using MediatR;

namespace LevvaCoins.Application.Transactions.Commands
{
    public class UpdateTransactionCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public TransactionTypeEnum Type { get; set; }
        public Guid CategoryId { get; set; }

        public UpdateTransactionCommand(Guid id, string description, double amount, TransactionTypeEnum type, Guid categoryId)
        {
            Id = id;
            Description = description;
            Amount = amount;
            Type = type;
            CategoryId = categoryId;
        }
    }
}
