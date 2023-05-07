using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevvaCoins.Domain.Entities;

namespace LevvaCoins.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<User, Guid>
    {
        Task<User?> GetByEmailAsync(string email);
    }
}
