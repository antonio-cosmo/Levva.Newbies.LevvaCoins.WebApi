using LevvaCoins.Domain.Enums;

namespace LevvaCoins.Application.Transactions.Dtos
{
    public class CreateTransactionDto
    {
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public Guid CategoryId { get; set; }
    }
}
