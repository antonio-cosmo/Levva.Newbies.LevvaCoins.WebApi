using LevvaCoins.Application.UseCases.Categories.Common;
using LevvaCoins.Domain.Enums;

namespace LevvaCoins.Application.UseCases.Transactions.Dtos
{
    public class TransactionDetailsDto
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public ETransactionType Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public CategoryOutput? Category { get; set; }
    }
}
