using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Interfaces.Repositories;
using LevvaCoins.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LevvaCoins.Infra.Data.Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        readonly MysqlDbContext _context;
        public CategoryRepository(MysqlDbContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var category = await GetByIdAsync(id);
            if (category == null) return false;

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<ICollection<Category>> GetAllAsync()
        {
            return await _context.Categories.AsNoTracking().ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(Guid id)
        {
            var category = await _context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            return category;
        }

        public async Task<Category?> GetByDescriptionAsync(string description)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.Description == description);
        }

        public async Task SaveAsync(Category obj)
        {
            _context.Categories.Add(obj);
            await _context.SaveChangesAsync();

        }

        public async Task<bool> UpdateAsync(Category obj)
        {
            _context.Categories.Update(obj);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
