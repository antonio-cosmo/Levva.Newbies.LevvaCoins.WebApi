using LevvaCoins.Domain.Common;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.SeedWork;

namespace LevvaCoins.Domain.Repositories
{
    public interface ITransactionRepository : IGenericRepository<Transaction, Guid>
    {
        Task<IEnumerable<Transaction>> GetAllAsync();
        Task<PagedResult<Transaction>> GetByUserPagedAsync(Guid userId, PaginationOptions paginationOptions);
        Task<IEnumerable<Transaction>> SearchByDescriptionAsync(Guid userId, string searchTerm);
        Task<IEnumerable<Transaction>> GetAllByUserAsync(Guid userId);
    }
}
