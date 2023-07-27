using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.SeedWork;

namespace LevvaCoins.Domain.Repositories
{
    public interface ITransactionRepository : IGenericRepository<Transaction, Guid>
    {
        Task<IEnumerable<Transaction>> GetAllAsync(CancellationToken cancellationToken);
        Task<IEnumerable<Transaction>> SearchByDescriptionAsync(Guid userId, string searchTerm, CancellationToken cancellationToken);
        Task<IEnumerable<Transaction>> GetAllByUserAsync(Guid userId, CancellationToken cancellationToken);
    }
}
