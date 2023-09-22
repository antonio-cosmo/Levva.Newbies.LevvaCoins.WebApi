using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Repositories;
using LevvaCoins.Infra.Data.Interface;

namespace LevvaCoins.Infra.Data.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(IContext context) : base(context)
    {
    }
}