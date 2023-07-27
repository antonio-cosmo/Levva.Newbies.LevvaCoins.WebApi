using LevvaCoins.Domain.Repositories;

namespace LevvaCoins.Domain.SeedWork;
public interface IUnitOfWork
{
    public ICategoryRepository CategoryRepository { get; }
    public ITransactionRepository TransactionRepository { get; }
    public IUserRepository UserRepository { get; }
    Task CommitAsync(CancellationToken cancellationToken);
}
