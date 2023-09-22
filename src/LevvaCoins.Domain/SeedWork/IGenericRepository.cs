using System.Linq.Expressions;

namespace LevvaCoins.Domain.SeedWork;

public interface IGenericRepository<TEntity> : IRepository
    where TEntity : class
{
    Task InsertAsync(TEntity entity, CancellationToken cancellationToken);
    Task<TEntity?> GetByPredicateAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken);
    IQueryable<TEntity> GetAllIncludeAsync(params Expression<Func<TEntity, object>>[] includeProperties);
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    Task RemoveAsync(TEntity entity, CancellationToken cancellationToken);
}