using LevvaCoins.Domain.Interfaces.Repositories;
using LevvaCoins.Infra.Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace LevvaCoins.Infra.Data.Repositories
{
    public class Repository<TEntity> : IRepositoryBase<TEntity, Guid> where TEntity : class 
    {
        private readonly IContext _context;
        private readonly DbSet<TEntity> _entity;
        public IQueryable<TEntity> Entity => _entity;

        public Repository(IContext context)
        {
            _context = context;
            _entity = _context.Set<TEntity>();
        }

        public async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await _entity.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await _entity.FindAsync(id);
        }

        public async Task<bool> RemoveAsync(TEntity obj)
        {
            _entity.Remove(obj);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<TEntity> SaveAsync(TEntity obj)
        {
            _entity.Add(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        public async Task<bool> UpdateAsync(TEntity obj)
        {
            _entity.Update(obj);
            await _context.SaveChangesAsync(); 
            return true;
        }
    }
}
