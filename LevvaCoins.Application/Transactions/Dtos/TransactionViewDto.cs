using LevvaCoins.Application.Categories.Dtos;
using LevvaCoins.Domain.Enums;

namespace LevvaCoins.Application.Transactions.Dtos
{
    public class TransactionViewDto
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Description { get; set; } = string.Empty;
        public double Amount { get; set; }
        public string Type { get; set; } = string.Empty;
        public CategoryDto? Category { get; set; }
        public TransactionViewDto(TransactionTypeEnum type) {
            Type = type.ToString();
        }
    }
}
