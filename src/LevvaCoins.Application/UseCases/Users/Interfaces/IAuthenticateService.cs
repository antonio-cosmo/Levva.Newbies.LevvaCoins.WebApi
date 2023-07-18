using LevvaCoins.Application.UseCases.Users.Dtos;

namespace LevvaCoins.Application.UseCases.Users.Interfaces
{
    public interface IAuthenticateService
    {
        Task<LoginResponseDto> GenerateToken(LoginDto login);
    }
}
