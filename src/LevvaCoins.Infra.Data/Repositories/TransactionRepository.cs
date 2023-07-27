using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Repositories;
using LevvaCoins.Infra.Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace LevvaCoins.Infra.Data.Repositories
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(IContext context) : base(context) { }
        public async Task<IEnumerable<Transaction>> GetAllByUserAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            return await Entity.Include(x => x.Category)
                                .AsNoTracking()
                                .Where(x => x.UserId.Equals(userId))
                                .OrderByDescending(x => x.CreatedAt)
                                .ToListAsync(cancellationToken);
        }
        public async Task<IEnumerable<Transaction>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await Entity.Include(x => x.Category)
                                .AsNoTracking()
                                .ToListAsync(cancellationToken);
        }
        public async Task<IEnumerable<Transaction>> SearchByDescriptionAsync(
            Guid userId,
            string searchTerm,
            CancellationToken cancellationToken = default
        )
        {
            return await Entity.Include(x => x.Category)
                                    .AsNoTracking()
                                    .Where(x => x.UserId.Equals(userId))
                                    .Where(x =>
                                          EF.Functions.Like(x.Description, $"%{searchTerm}%") ||
                                          EF.Functions.Like(x.Category!.Description, $"%{searchTerm}%")
                                     )
                                    .OrderByDescending(x => x.CreatedAt)
                                    .ToListAsync(cancellationToken);
        }
    }
}
