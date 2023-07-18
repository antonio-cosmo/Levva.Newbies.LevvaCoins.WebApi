using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.SeedWork;

namespace LevvaCoins.Domain.Repositories
{
    public interface IUserRepository : IGenericRepository<User, Guid>
    {
        Task<ICollection<User>> GetAllAsync(CancellationToken cancellationToken);
        Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);
    }
}
