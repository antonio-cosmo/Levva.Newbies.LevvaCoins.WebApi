using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Interfaces.Repositories;
using LevvaCoins.Infra.Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace LevvaCoins.Infra.Data.Repositories
{
    public class UserRepository : Repository<User> ,IUserRepository
    {
        public UserRepository(IContext context) : base(context) { }
        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _entity.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);

        }
     
    }
}
