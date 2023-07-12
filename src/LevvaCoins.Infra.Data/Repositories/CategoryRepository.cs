using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Repositories;
using LevvaCoins.Infra.Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace LevvaCoins.Infra.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(IContext context): base(context)
        {
        }

        public async Task<ICollection<Category>> GetAllAsync()
        {
            return await Entity.AsNoTracking().ToListAsync();
        }

        public async Task<Category?> GetByDescriptionAsync(string name)
        {
            return await Entity.AsNoTracking().FirstOrDefaultAsync(x => x.Description.Text.Equals(name));
        }
    }
}
