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

        public async Task<bool> RemoveAsync(User obj)
        {
            _context.Users.Remove(obj);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<ICollection<User>> GetAllAsync()
        {
            return await _context.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);

        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

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
