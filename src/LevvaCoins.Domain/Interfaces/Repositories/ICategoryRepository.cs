using LevvaCoins.Domain.Entities;

namespace LevvaCoins.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository: IRepositoryBase<Category, Guid>
    {
        Task<Category?> GetByDescriptionAsync(string name);
        Task<ICollection<Category>> GetAllAsync();

    }
}
