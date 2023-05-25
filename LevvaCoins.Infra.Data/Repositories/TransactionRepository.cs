using LevvaCoins.Domain.Common;
using LevvaCoins.Domain.Common.Dtos;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Interfaces.Repositories;
using LevvaCoins.Infra.Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace LevvaCoins.Infra.Data.Repositories
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(IContext context): base(context) { }
        public async Task<PagedResultDto<Transaction>> GetTransactionByUser(Guid userId, PaginationOptions paginationOptions)
        {
            var items = await _entity.AsNoTracking()
                                              .Where(x => x.UserId == userId)
                                              .OrderBy(x => x.CreatedAt)
                                              .Skip((paginationOptions.PageNumber - 1) * paginationOptions.PageSize)
                                              .Take(paginationOptions.PageSize)
                                              .ToListAsync();

            return new PagedResultDto<Transaction>(
                   items: items,
                   pageNumber: paginationOptions.PageNumber,
                   pageSize: paginationOptions.PageSize,
                   totalElements: items.Count()
               );
        }

        public async Task<IEnumerable<Transaction>> SearchTransactionByDescription(string search)
        {
            var result = await _entity
                                    .AsNoTracking()
                                    .Where(t => EF.Functions.Like(t.Description, $"%{search}%"))
                                    .ToListAsync();
            return result;
        }
    }
}
