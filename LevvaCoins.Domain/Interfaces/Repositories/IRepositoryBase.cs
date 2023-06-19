namespace LevvaCoins.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity, UId>
    {
        Task<TEntity> SaveAsync(TEntity entity);
        Task<TEntity?> GetByIdAsync(UId id);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
    }
}
