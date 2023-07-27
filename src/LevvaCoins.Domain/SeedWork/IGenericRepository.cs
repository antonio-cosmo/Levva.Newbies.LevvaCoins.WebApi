namespace LevvaCoins.Domain.SeedWork
{
    public interface IGenericRepository<TEntity, TId> : IRepository
        where TEntity : Entity
    {
        Task InsertAsync(TEntity entity, CancellationToken cancellationToken);
        Task<TEntity?> GetAsync(TId id, CancellationToken cancellationToken);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
        Task RemoveAsync(TEntity entity, CancellationToken cancellationToken);
    }
}
