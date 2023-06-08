using LevvaCoins.Domain.Common;
using LevvaCoins.Domain.Entities;

namespace LevvaCoins.Domain.Interfaces.Repositories
{
    public interface ITransactionRepository : IRepositoryBase<Transaction, Guid>
    {
        Task<PagedResult<Transaction>> GetbyUserIdAndIncludeCategory(Guid userId, PaginationOptions paginationOptions);
        Task<IEnumerable<Transaction>> SearchByDescriptionAndIncludeCategory(Guid userId, string text);
        Task<Transaction?> GetByIdAndIncludeCategory(Guid transactionId);
        Task<IEnumerable<Transaction>> GetAllAndIncludeCategories(Guid userId);
    }
}
