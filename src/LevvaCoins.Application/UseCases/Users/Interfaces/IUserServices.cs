using LevvaCoins.Application.UseCases.Users.Dtos;
using LevvaCoins.Domain.Entities;

namespace LevvaCoins.Application.UseCases.Users.Interfaces
{
    public interface IUserServices
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> SaveAsync(CreateUserDto createUserDto);
        Task UpdateAsync(Guid id, UpdateUserDto updateUserDto);
        Task RemoveAsync(Guid id);
        Task<UserDto> GetByIdAsync(Guid id);
        Task<User?> GetByEmailAsync(string email);


    }
}
