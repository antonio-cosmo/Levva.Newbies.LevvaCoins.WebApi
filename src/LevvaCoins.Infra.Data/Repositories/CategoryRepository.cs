using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Repositories;
using LevvaCoins.Infra.Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace LevvaCoins.Infra.Data.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IContext context): base(context)
        {
        }
        public async Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await Entity.AsNoTracking().ToListAsync(cancellationToken);
        }
        public async Task<Category?> GetByDescriptionAsync(string name, CancellationToken cancellationToken = default)
        {
            return await Entity.AsNoTracking().FirstOrDefaultAsync(x => EF.Functions.Like(x.Description.Text, $"{name}"), cancellationToken);
        }
    }
}
