using LevvaCoins.Application.Categories.Dtos;
using LevvaCoins.Domain.Enums;

namespace LevvaCoins.Application.Transactions.Dtos
{
    public class TransactionDetailsDto
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public double Amount { get; set; }
        public TransactionType Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public CategoryDto? Category { get; set; }
    }
}
