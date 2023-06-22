using LevvaCoins.Application.Users.Dtos;

namespace LevvaCoins.Application.Users.Interfaces
{
    public interface IAuthenticateService
    {
        Task<LoginResponseDto> GenerateToken(LoginDto login);
    }
}
