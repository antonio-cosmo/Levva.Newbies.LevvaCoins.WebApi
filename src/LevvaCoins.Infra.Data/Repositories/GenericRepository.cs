using System.Linq.Expressions;
using LevvaCoins.Domain.SeedWork;
using LevvaCoins.Infra.Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace LevvaCoins.Infra.Data.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly DbSet<TEntity> _entity;

    protected GenericRepository(IContext context)
    {
        _entity = context.Set<TEntity>();
    }

    protected IQueryable<TEntity> Entity => _entity;

    public Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_entity.Remove(entity));
    }

    public async Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _entity.AddAsync(entity, cancellationToken);
    }

    public async Task<TEntity?> GetByPredicateAsync(Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken)
    {
        return await _entity.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _entity.FindAsync(new object?[] { id }, cancellationToken);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await Entity.ToListAsync(cancellationToken);
    }

    public IQueryable<TEntity> GetAllIncludeAsync(params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> query = _entity;
        return includeProperties.Aggregate(
            query,
            (current, includeProperty) => current.Include(includeProperty)
        );
    }

    public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_entity.Update(entity));
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        return await _entity.FirstOrDefaultAsync(predicate, cancellationToken);
    }
}