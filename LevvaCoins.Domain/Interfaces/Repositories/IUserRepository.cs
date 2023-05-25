using LevvaCoins.Domain.Entities;

namespace LevvaCoins.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<User, Guid>
    {
        Task<User?> GetByEmailAsync(string email);
    }
}
