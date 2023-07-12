using LevvaCoins.Domain.Common;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Repositories;
using LevvaCoins.Infra.Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace LevvaCoins.Infra.Data.Repositories
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(IContext context): base(context) { }

        public async Task<IEnumerable<Transaction>> GetAllByUserAsync(Guid userId)
        {
            return await Entity.Include(x => x.Category)
                                .AsNoTracking()
                                .Where(x => x.UserId.Equals(userId))
                                .OrderByDescending(x => x.CreatedAt)
                                .ToListAsync();
        }

        public async Task<IEnumerable<Transaction>> GetAllAsync()
        {
            return await Entity.Include(x => x.Category)
                                .AsNoTracking()
                                .ToListAsync();
        }

        public async Task<PagedResult<Transaction>> GetByUserPagedAsync(Guid userId, PaginationOptions paginationOptions)
        {
            var items = await Entity
                .Include(x => x.Category)
                .AsNoTracking()
                .Where(x => x.UserId.Equals(userId))
                .ToListAsync();

            items = items.OrderByDescending(x => x.CreatedAt).ToList();

            var pagedItems = items
                .Skip((paginationOptions.PageNumber - 1) * paginationOptions.PageSize)
                .Take(paginationOptions.PageSize);

            return new PagedResult<Transaction>(
                   items: pagedItems,
                   pageNumber: paginationOptions.PageNumber,
                   pageSize: paginationOptions.PageSize,
                   totalElements: items.Count
               );
        }

        public async Task<IEnumerable<Transaction>> SearchByDescriptionAsync(Guid userId, string searchTerm)
        {
            var result = await Entity.Include(x => x.Category)
                                    .AsNoTracking()
                                    .Where(x => x.UserId.Equals(userId))
                                    .Where(x =>
                                                EF.Functions.Like(x.Description.Text, $"%{searchTerm}%") ||
                                                EF.Functions.Like(x.Category!.Description.Text, $"%{searchTerm}%")
                                          )
                                    .OrderByDescending(x => x.CreatedAt)
                                    .ToListAsync();

            return result;
        }
    }
}
