using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Repositories;
using LevvaCoins.Infra.Data.Interface;

namespace LevvaCoins.Infra.Data.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(IContext context) : base(context)
    {
    }
}