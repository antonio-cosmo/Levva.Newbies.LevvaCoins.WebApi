using LevvaCoins.Application.Transactions.Dtos;
using LevvaCoins.Domain.Common;
using LevvaCoins.Domain.Common.Dtos;

namespace LevvaCoins.Application.Transactions.Interfaces
{
    public interface ITransactionServices
    {
        Task CreateTransactionAsync(CreateTransactionDto transaction, string userId);
        Task<IEnumerable<TransactionDto>> GetAllTransactionsAsync();
        Task<PagedResultDto<TransactionDto>> GetAllTransactionsAsync(PaginationOptions paginationOptions);
        Task<TransactionDto> GetByIdTransaction(Guid transactionId);
        Task UpdateTransaction(Guid id, UpdateTransactionDto transaction);
        Task DeleteByIdTransaction(Guid transactionId);
        Task<IEnumerable<TransactionDto>> SearchTransactionByuser(Guid userId);
    }
}
