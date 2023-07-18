using LevvaCoins.Domain.Enums;

namespace LevvaCoins.Application.UseCases.Transactions.Dtos
{
    public class CreateTransactionDto
    {
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public ETransactionType Type { get; set; }
        public Guid CategoryId { get; set; }
    }
}
