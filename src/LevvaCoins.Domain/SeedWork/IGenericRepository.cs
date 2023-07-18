namespace LevvaCoins.Domain.SeedWork
{
    public interface IGenericRepository<TEntity, UId> : IRepository
        where TEntity : Entity
    {
        Task InsertAsync(TEntity entity, CancellationToken cancellationToken);
        Task<TEntity?> GetAsync(UId id, CancellationToken cancellationToken);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
        Task RemoveAsync(TEntity entity, CancellationToken cancellationToken);
    }
}
