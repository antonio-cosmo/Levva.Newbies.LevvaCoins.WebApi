using LevvaCoins.Domain.Common;
using LevvaCoins.Domain.Common.Dtos;
using LevvaCoins.Domain.Entities;

namespace LevvaCoins.Domain.Interfaces.Repositories
{
    public interface ITransactionRepository : IRepositoryBase<Transaction, Guid>
    {
        Task<PagedResultDto<Transaction>> GetTransactionByUser(Guid userId, PaginationOptions paginationOptions);
        Task<IEnumerable<Transaction>> SearchTransactionByDescription(string text);
    }
}
