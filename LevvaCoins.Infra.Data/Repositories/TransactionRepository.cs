using LevvaCoins.Domain.Common;
using LevvaCoins.Domain.Common.Dtos;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Interfaces.Repositories;
using LevvaCoins.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LevvaCoins.Infra.Data.Repositories
{
    public class TransactionRepository: ITransactionRepository
    {
        readonly MysqlDbContext _context;
        public TransactionRepository(MysqlDbContext context)
        {
            _context = context;
        }
        public async Task<bool> RemoveAsync(Transaction obj)
        {
            _context.Transactions.Remove(obj);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<Transaction>> GetAllAsync()
        {
            return await _context.Transactions.AsNoTracking().ToListAsync();
        }

        public async Task<PagedResultDto<Transaction>> GetAllTransactions(PaginationOptions options)
        {
            var totalElements = _context.Transactions.Count();
            var items = await _context.Transactions.AsNoTracking()
                .OrderBy(x => x.CreatedAt)
                .Skip((options.PageNumber -1) * options.PageSize)
                .Take(options.PageSize)
                .ToListAsync();
            
            return new PagedResultDto<Transaction>(
                    items: items, 
                    pageNumber: options.PageNumber, 
                    pageSize: options.PageSize, 
                    totalElements: totalElements
                );
        }

        public async Task<Transaction?> GetByIdAsync(Guid id)
        {
            return await _context.Transactions.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PagedResultDto<Transaction>> GetTransactionByUser(Guid userId, PaginationOptions options)
        {

            var items = await _context.Transactions.AsNoTracking()
                                              .Where(x => x.UserId == userId)
                                              .OrderBy(x => x.CreatedAt)
                                              .Skip((options.PageNumber - 1) * options.PageSize)
                                              .Take(options.PageSize)
                                              .ToListAsync();

            return new PagedResultDto<Transaction>(
                   items: items,
                   pageNumber: options.PageNumber,
                   pageSize: options.PageSize,
                   totalElements: items.Count()
               );
        }

        public async Task SaveAsync(Transaction obj)
        {
            _context.Transactions.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Transaction>> SearchTransactionByDescription(string search)
        {
            var result = await _context.Transactions
                                    .AsNoTracking()
                                    .Where(t => EF.Functions.Like(t.Description, $"%{search}%"))
                                    .ToListAsync();
            return result;
        }

        public async Task<bool> UpdateAsync(Transaction obj)
        {
            _context.Update(obj);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
