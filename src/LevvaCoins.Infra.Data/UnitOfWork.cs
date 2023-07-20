using LevvaCoins.Domain.SeedWork;

namespace LevvaCoins.Infra.Data;
public class UnitOfWork : IUnitOfWork
{
    private readonly LevvaCoinsDbContext _context;

    public UnitOfWork(LevvaCoinsDbContext context)
    {
        _context = context;
    }
    public Task CommitAsync(CancellationToken cancellationToken)
        => _context.SaveChangesAsync(cancellationToken);
}
