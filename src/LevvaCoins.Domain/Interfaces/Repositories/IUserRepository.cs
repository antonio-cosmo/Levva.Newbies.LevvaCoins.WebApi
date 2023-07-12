using LevvaCoins.Domain.Entities;

namespace LevvaCoins.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<User, Guid>
    {
        Task<ICollection<User>> GetAllAsync();
        Task<User?> GetByEmailAsync(string email);
    }
}
