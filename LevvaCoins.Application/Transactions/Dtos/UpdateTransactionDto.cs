using LevvaCoins.Domain.Enums;

namespace LevvaCoins.Application.Transactions.Dtos
{
    public class UpdateTransactionDto
    {
        public string? Description { get; set; }
        public double Amount { get; set; }
        public TransactionType Type { get; set; }
        public Guid CategoryId { get; set; }
    }
}
