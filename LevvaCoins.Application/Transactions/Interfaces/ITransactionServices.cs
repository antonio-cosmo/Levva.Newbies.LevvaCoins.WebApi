using LevvaCoins.Application.Transactions.Dtos;
using LevvaCoins.Domain.Common;

namespace LevvaCoins.Application.Transactions.Interfaces
{
    public interface ITransactionServices
    {
        Task CreateTransactionAsync(CreateTransactionDto transaction, Guid userId);
        Task<IEnumerable<TransactionViewDto>> GetAllTransactions(Guid userId);
        Task<TransactionViewDto> GetByIdTransaction(Guid transactionId);
        Task UpdateTransaction(Guid id, UpdateTransactionDto transaction);
        Task DeleteByIdTransaction(Guid transactionId);
        Task<PagedResult<TransactionViewDto>> SearchTransactionByUser(Guid userId, PaginationOptions paginationOptions);
        Task<IEnumerable<TransactionViewDto>> SearchTransactionByDescription(string search);
    }
}
