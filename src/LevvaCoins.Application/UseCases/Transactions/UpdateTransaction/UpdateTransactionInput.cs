using LevvaCoins.Domain.Enums;
using MediatR;

namespace LevvaCoins.Application.UseCases.Transactions.UpdateTransaction
{
    public class UpdateTransactionInput : IRequest
    {
        public Guid Id { get; }
        public string Description { get; }
        public decimal Amount { get; }
        public ETransactionType Type { get; }
        public Guid CategoryId { get; }

        public UpdateTransactionInput(Guid id, string description, decimal amount, ETransactionType type, Guid categoryId)
        {
            Id = id;
            Description = description;
            Amount = amount;
            Type = type;
            CategoryId = categoryId;
        }
    }
}
