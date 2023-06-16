using LevvaCoins.Application.Accounts.Dtos;
using LevvaCoins.Domain.Entities;

namespace LevvaCoins.Application.Accounts.Interfaces
{
    public interface IAccountServices
    {
        Task<IEnumerable<AccountDto>> GetAllAsync();
        Task<AccountDto> SaveAsync(SaveAccountDto accountDto);
        Task UpdateAsync(Guid id, UpdateAccountDto accountDto);
        Task RemoveAsync(Guid id);
        Task<AccountDto> GetByIdAsync(Guid id);
        Task<User?> GetByEmailAsync(string email);


    }
}
