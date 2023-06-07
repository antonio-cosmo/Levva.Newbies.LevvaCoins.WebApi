using LevvaCoins.Domain.Common;
using LevvaCoins.Domain.Entities;

namespace LevvaCoins.Domain.Interfaces.Repositories
{
    public interface ITransactionRepository : IRepositoryBase<Transaction, Guid>
    {
        Task<PagedResult<Transaction>> GetTransactionByUserIdIncludingCategory(Guid userId, PaginationOptions paginationOptions);
        Task<IEnumerable<Transaction>> SearchTransactionByDescription(string text);
        Task<Transaction?> GetTransactionByIdIncludingCategory(Guid transactionId);
        Task<IEnumerable<Transaction>> GetAllTransactionIncludingCategory(Guid userId);
    }
}
