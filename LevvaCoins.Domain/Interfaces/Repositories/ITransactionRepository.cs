using LevvaCoins.Domain.Common;
using LevvaCoins.Domain.Entities;

namespace LevvaCoins.Domain.Interfaces.Repositories
{
    public interface ITransactionRepository : IRepositoryBase<Transaction, Guid>
    {
        Task<PagedResult<Transaction>> GetByUserIdAndIncludeCategoryAsync(Guid userId, PaginationOptions paginationOptions);
        Task<IEnumerable<Transaction>> SearchByDescriptionAndIncludeCategoryAsync(Guid userId, string text);
        Task<Transaction?> GetByIdAndIncludeCategoryAsync(Guid transactionId);
        Task<IEnumerable<Transaction>> GetAllAndIncludeCategoriesAsync(Guid userId);
    }
}
