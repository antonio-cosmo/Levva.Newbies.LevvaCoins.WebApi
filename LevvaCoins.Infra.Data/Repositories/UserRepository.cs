using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Interfaces.Repositories;
using LevvaCoins.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LevvaCoins.Infra.Data.Repositories
{
    public class UserRepository: IUserRepository
    {
        readonly MysqlDbContext _context;
        public UserRepository(MysqlDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var user = await GetByIdAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<ICollection<User>> GetAllAsync()
        {
            return await _context.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);

            return user;
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            return user;
        }

        public async Task SaveAsync(User obj)
        {
            _context.Users.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(User obj)
        {
            _context.Users.Update(obj);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
