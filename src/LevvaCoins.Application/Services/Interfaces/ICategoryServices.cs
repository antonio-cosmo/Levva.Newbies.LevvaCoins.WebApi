using LevvaCoins.Application.Commands.Requests.Category;
using LevvaCoins.Application.Responses;

namespace LevvaCoins.Application.Services.Interfaces;

public interface ICategoryServices
{
    Task<CategoryModelResponse?> InsertAsync(CreateCategoryRequest request, CancellationToken cancellationToken);
    Task<IEnumerable<CategoryModelResponse>> GetAllAsync(CancellationToken cancellationToken);
    Task<CategoryModelResponse> GetAsync(Guid id, CancellationToken cancellationToken);
    Task UpdateAsync(UpdateCategoryRequest request, CancellationToken cancellationToken);
    Task RemoveAsync(Guid id, CancellationToken cancellationToken);
}