namespace LevvaCoins.Application.Transactions.Dtos
{
    public class CreateTransactionDto
    {
        public string Description { get; set; } = string.Empty;
        public double Amount { get; set; }
        public string Type { get; set; } = string.Empty;
        public Guid CategoryId { get; set; }
    }
}
