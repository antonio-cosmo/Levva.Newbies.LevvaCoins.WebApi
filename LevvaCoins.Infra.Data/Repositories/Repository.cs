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
        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await _entity.FindAsync(id);
        }
        public async Task RemoveAsync(TEntity entity)
        {
            _entity.Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<TEntity> SaveAsync(TEntity entity)
        {
            _entity.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        public async Task UpdateAsync(TEntity entity)
        {
            _entity.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
