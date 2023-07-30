using LevvaCoins.Application.Services.Dtos.User;

namespace LevvaCoins.Application.Services.Interfaces;
public interface IUserServices
{
    Task<UserModelResponse> InsertAsync(CreateUserRequest request, CancellationToken cancellationToken);
    Task<UserModelResponse> GetAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<UserModelResponse>> GetAllAsync(CancellationToken cancellationToken);
    Task RemoveAsync(Guid id, CancellationToken cancellationToken);
    Task UpdateAsync(UpdateUserRequest request, CancellationToken cancellationToken);
}
