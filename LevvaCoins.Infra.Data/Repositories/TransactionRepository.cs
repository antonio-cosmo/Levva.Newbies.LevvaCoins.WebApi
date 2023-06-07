using LevvaCoins.Domain.Common;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Interfaces.Repositories;
using LevvaCoins.Infra.Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace LevvaCoins.Infra.Data.Repositories
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(IContext context): base(context) { }

        public async Task<IEnumerable<Transaction>> GetAllTransactionIncludingCategory(Guid userId)
        {
            return await Entity.Include(x => x.Category)
                                .Where(x => x.UserId == userId)
                                .AsNoTracking()
                                .ToListAsync();
        }

        public async Task<Transaction?> GetTransactionByIdIncludingCategory(Guid transactionId)
        {
            return await _entity.Include(x => x.Category).AsNoTracking().FirstOrDefaultAsync(x => x.Id == transactionId);
        }

        public async Task<PagedResult<Transaction>> GetTransactionByUserIdIncludingCategory(Guid userId, PaginationOptions paginationOptions)
        {
            var items = await _entity.Include(x => x.Category).AsNoTracking()
                                              .Where(x => x.UserId == userId)
                                              .OrderBy(x => x.CreatedAt)
                                              .Skip((paginationOptions.PageNumber - 1) * paginationOptions.PageSize)
                                              .Take(paginationOptions.PageSize)
                                              .ToListAsync();

            return new PagedResult<Transaction>(
                   items: items,
                   pageNumber: paginationOptions.PageNumber,
                   pageSize: paginationOptions.PageSize,
                   totalElements: items.Count()
               );
        }

        public async Task<IEnumerable<Transaction>> SearchTransactionByDescription(string search)
        {
            var result = await _entity.Include(x => x.Category)
                                    .AsNoTracking()
                                    .Where(t => EF.Functions.Like(t.Description, $"%{search}%") || EF.Functions.Like(t.Category!.Description, $"%{search}%"))
                                    .ToListAsync();
            return result;
        }
    }
}
