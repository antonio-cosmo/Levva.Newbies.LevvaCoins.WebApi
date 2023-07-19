using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Repositories;
using LevvaCoins.Infra.Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace LevvaCoins.Infra.Data.Repositories
{
    public class UserRepository : GenericRepository<User> ,IUserRepository
    {
        public UserRepository(IContext context) : base(context) { }

        public async Task<ICollection<User>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await Entity.AsNoTracking().ToListAsync(cancellationToken);
        }
        public async Task<User?> GetByEmailAndPasswordAsync(string email, string password, CancellationToken cancellationToken = default)
        {
            return await Entity.AsNoTracking().FirstOrDefaultAsync(
                    x => x.Email.Equals(email) && x.Password.Equals(password),
                    cancellationToken
                );
        }
        public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await Entity.AsNoTracking().FirstOrDefaultAsync(
                    x => x.Email.Equals(email),
                    cancellationToken
                );
        }
    }
}
