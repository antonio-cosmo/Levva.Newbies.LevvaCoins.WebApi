using LevvaCoins.Domain.Enums;

namespace LevvaCoins.Application.Transactions.Dtos
{
    public class UpdateTransactionDto
    {
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public ETransactionType Type { get; set; }
        public Guid CategoryId { get; set; }
    }
}
