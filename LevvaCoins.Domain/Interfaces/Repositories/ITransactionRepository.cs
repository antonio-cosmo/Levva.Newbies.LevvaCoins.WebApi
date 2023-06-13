using LevvaCoins.Domain.Common;
using LevvaCoins.Domain.Entities;

namespace LevvaCoins.Domain.Interfaces.Repositories
{
    public interface ITransactionRepository : IRepositoryBase<Transaction, Guid>
    {
        Task<IEnumerable<Transaction>> GetAllAsync();
        Task<PagedResult<Transaction>> GetByUserPagedAsync(Guid userId, PaginationOptions paginationOptions);
        Task<IEnumerable<Transaction>> SearchByDescriptionAsync(Guid userId, string text);
        Task<IEnumerable<Transaction>> GetAllByUserAsync(Guid userId);
    }
}
