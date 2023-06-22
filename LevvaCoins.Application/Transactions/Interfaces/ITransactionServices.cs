using LevvaCoins.Application.Transactions.Dtos;
using LevvaCoins.Domain.Common;

namespace LevvaCoins.Application.Transactions.Interfaces
{
    public interface ITransactionServices
    {
        Task<TransactionDetailsDto> SaveAsync(Guid userId, CreateTransactionDto createTransactionDto);
        Task<IEnumerable<TransactionDetailsDto>> GetAllAsync(Guid userId);
        Task<TransactionDetailsDto> GetByIdAsync(Guid id);
        Task UpdateAsync(Guid id, UpdateTransactionDto updateTransactionDto);
        Task RemoveAsync(Guid id);
        Task<PagedResult<TransactionDetailsDto>> GetAllPagedAsync(Guid userId, PaginationOptions paginationOptions);
        Task<IEnumerable<TransactionDetailsDto>> SearchByDescriptionAsync(Guid userId, string search);
    }
}
