namespace LevvaCoins.Domain.SeedWork
{
    public interface IGenericRepository<TEntity, UId> : IRepository 
        where TEntity : Entity
    {
        Task InsertAsync(TEntity entity);
        Task<TEntity?> GetAsync(UId id);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
    }
}
