using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Interfaces.Repositories;
using LevvaCoins.Infra.Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace LevvaCoins.Infra.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(IContext context): base(context) { }
        public async Task<Category?> GetByDescriptionAsync(string name)
        {
            return await Entity.AsNoTracking().FirstOrDefaultAsync(x => x.Description == name);
        }
    }
}
