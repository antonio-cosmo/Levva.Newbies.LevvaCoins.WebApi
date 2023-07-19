using LevvaCoins.Domain.SeedWork;

namespace LevvaCoins.Infra.Data;
public class UnitOfWork : IUnitOfWork
{
    private readonly LevvaCoinsDbContext _context;

    public UnitOfWork(LevvaCoinsDbContext context)
    {
        _context = context;
    }
    public async Task CommitAsync(CancellationToken cancellationToken)
        => await _context.SaveChangesAsync(cancellationToken);
}
