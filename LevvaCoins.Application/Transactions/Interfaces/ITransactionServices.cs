using LevvaCoins.Application.Transactions.Dtos;


namespace LevvaCoins.Application.Transactions.Interfaces
{
    public interface ITransactionServices
    {
        Task CreateTransactionAsync(CreateTransactionDto transaction, string userId);
        Task<IEnumerable<TransactionDto>> GetAllTransactionsAsync();
        Task<TransactionDto> GetByIdTransaction(Guid transactionId);
        Task DeleteByIdTransaction(Guid transactionId);
        Task<IEnumerable<TransactionDto>> SearchTransactionByuser(Guid userId);
    }
}
