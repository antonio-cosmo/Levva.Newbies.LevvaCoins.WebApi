using LevvaCoins.Domain.SeedWork;
using LevvaCoins.Infra.Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace LevvaCoins.Infra.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity, Guid> where TEntity : Entity
    {
        private readonly IContext _context;
        private readonly DbSet<TEntity> _entity;
        public IQueryable<TEntity> Entity => _entity;
        public GenericRepository(IContext context)
        {
            _context = context;
            _entity = _context.Set<TEntity>();
        }
        public async Task<TEntity?> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _entity.FindAsync(id, cancellationToken);
        }
        public Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(_entity.Remove(entity));
        }
        public async Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _entity.AddAsync(entity, cancellationToken);
        }
        public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(_entity.Update(entity));
        }
    }
}
