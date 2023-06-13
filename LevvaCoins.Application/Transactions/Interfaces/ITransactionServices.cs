using LevvaCoins.Application.Transactions.Dtos;
using LevvaCoins.Domain.Common;

namespace LevvaCoins.Application.Transactions.Interfaces
{
    public interface ITransactionServices
    {
        Task<TransactionViewDto> SaveAsync(SaveTransactionDto transaction, Guid userId);
        Task<IEnumerable<TransactionViewDto>> GetAllAsync(Guid userId, string? searchDescription);
        Task<TransactionViewDto> GetByIdAsync(Guid transactionId);
        Task UpdateAsync(Guid id, UpdateTransactionDto transaction);
        Task RemoveAsync(Guid transactionId);
        Task<PagedResult<TransactionViewDto>> GetAllPagedAsync(Guid userId, PaginationOptions paginationOptions);
    }
}
