using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LevvaCoins.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity, TId>
    {
        Task SaveAsync(TEntity obj);
        Task<TEntity?> GetByIdAsync(TId id);
        Task<ICollection<TEntity>> GetAllAsync();
        Task<bool> UpdateAsync(TEntity obj);
        Task<bool> DeleteByIdAsync(TId id);
    }
}
