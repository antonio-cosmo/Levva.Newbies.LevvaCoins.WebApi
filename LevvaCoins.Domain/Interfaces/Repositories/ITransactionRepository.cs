using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevvaCoins.Domain.Common;
using LevvaCoins.Domain.Common.Dtos;
using LevvaCoins.Domain.Entities;

namespace LevvaCoins.Domain.Interfaces.Repositories
{
    public interface ITransactionRepository : IRepositoryBase<Transaction, Guid>
    {
        Task<IEnumerable<Transaction>> GetTransactionByUser(Guid userId);
        Task<PagedResultDto<Transaction>> GetAllTransactions(PaginationOptions paginationOptions);
    }
}
