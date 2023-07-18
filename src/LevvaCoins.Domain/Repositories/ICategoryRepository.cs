using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.SeedWork;

namespace LevvaCoins.Domain.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category, Guid>
    {
        Task<Category?> GetByDescriptionAsync(string name, CancellationToken cancellationToken);
        Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken);
    }
}
