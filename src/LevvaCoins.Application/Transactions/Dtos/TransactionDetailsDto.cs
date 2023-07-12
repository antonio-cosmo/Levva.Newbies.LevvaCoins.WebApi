using LevvaCoins.Application.Categories.Dtos;
using LevvaCoins.Domain.Enums;

namespace LevvaCoins.Application.Transactions.Dtos
{
    public class TransactionDetailsDto
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public ETransactionType Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public CategoryDto? Category { get; set; }
    }
}
