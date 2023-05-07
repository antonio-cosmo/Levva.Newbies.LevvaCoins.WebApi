using LevvaCoins.Application.Accounts.Dtos;
using LevvaCoins.Domain.Entities;

namespace LevvaCoins.Application.Accounts.Interfaces
{
    public interface IAccountServices
    {
        Task<IEnumerable<AccountDto>> GetAllAccountAsync();
        Task CreateAccountAsync(CreateAccountDto accountDto);
        Task UpdateAccountAsync(Guid id, UpdateAccountDto accountDto);
        Task DeleteAccountAsync(Guid id);
        Task<AccountDto> GetAccountByIdAsync(Guid id);
        Task<User> GetAccountByEmailAsync(string email);
    }
}
