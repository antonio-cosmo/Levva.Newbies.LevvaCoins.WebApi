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

        public async Task<IEnumerable<Transaction>> GetAllAndIncludeCategories(Guid userId)
        {
            return await Entity.Include(x => x.Category)
                                .Where(x => x.UserId == userId)
                                .OrderByDescending(x => x.CreatedAt)
                                .AsNoTracking()
                                .ToListAsync();
        }

        public async Task<Transaction?> GetByIdAndIncludeCategory(Guid transactionId)
        {
            return await _entity.Include(x => x.Category).AsNoTracking().FirstOrDefaultAsync(x => x.Id == transactionId);
        }

        public async Task<PagedResult<Transaction>> GetbyUserIdAndIncludeCategory(Guid userId, PaginationOptions paginationOptions)
        {
            var items = await _entity.Include(x => x.Category).AsNoTracking()
                                              .Where(x => x.UserId == userId)
                                              .OrderByDescending(x => x.CreatedAt)
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

        public async Task<IEnumerable<Transaction>> SearchByDescriptionAndIncludeCategory(Guid userId, string search)
        {
            var result = await _entity.Include(x => x.Category)
                                    .AsNoTracking()
                                    .Where(x => x.UserId == userId)
                                    .Where(x => 
                                                EF.Functions.Like(x.Description, $"%{search}%") || 
                                                EF.Functions.Like(x.Category!.Description, $"%{search}%") ||
                                                EF.Functions.Like(x.Amount.ToString(), $"%{search}%")
                                          )
                                    .OrderByDescending(x => x.CreatedAt)
                                    .ToListAsync();
            return result;
        }
    }
}
