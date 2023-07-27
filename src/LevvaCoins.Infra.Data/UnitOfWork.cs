using LevvaCoins.Domain.Repositories;
using LevvaCoins.Domain.SeedWork;
using LevvaCoins.Infra.Data.Repositories;

namespace LevvaCoins.Infra.Data;
public class UnitOfWork : IUnitOfWork
{
    private readonly LevvaCoinsDbContext _context;
    public ICategoryRepository CategoryRepository { get; }
    public ITransactionRepository TransactionRepository { get; }
    public IUserRepository UserRepository { get; }
    public UnitOfWork(LevvaCoinsDbContext context)
    {
        _context = context;
        CategoryRepository = new CategoryRepository(_context);
        TransactionRepository = new TransactionRepository(_context);
        UserRepository = new UserRepository(_context);
    }
    public Task CommitAsync(CancellationToken cancellationToken)
        => _context.SaveChangesAsync(cancellationToken);
}
