namespace LevvaCoins.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity, TId>
    {
        Task<TEntity> SaveAsync(TEntity obj);
        Task<TEntity?> GetByIdAsync(TId id);
        Task UpdateAsync(TEntity obj);
        Task RemoveAsync(TEntity obj);
    }
}
