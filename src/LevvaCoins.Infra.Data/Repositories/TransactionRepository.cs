using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Repositories;
using LevvaCoins.Infra.Data.Interface;

namespace LevvaCoins.Infra.Data.Repositories;

public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
{
    public TransactionRepository(IContext context) : base(context)
    {
    }
}