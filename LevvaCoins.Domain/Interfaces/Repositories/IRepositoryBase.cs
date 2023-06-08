namespace LevvaCoins.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity, TId>
    {
        Task<TEntity> SaveAsync(TEntity obj);
        Task<TEntity?> GetByIdAsync(TId id);
        Task<ICollection<TEntity>> GetAllAsync();
        Task<bool> UpdateAsync(TEntity obj);
        Task<bool> RemoveAsync(TEntity obj);
    }
}
