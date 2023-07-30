using LevvaCoins.Application.Services.Dtos.Category;

namespace LevvaCoins.Application.Services.Interfaces;
public interface ICategoryServices
{
    Task<CategoryModelResponse> InsertAsync(CreateCategoryRequest request, CancellationToken cancellationToken);
    Task<IEnumerable<CategoryModelResponse>> GetallAsync(CancellationToken cancellationToken);
    Task<CategoryModelResponse> GetAsync(Guid id,CancellationToken cancellationToken);
    Task Updateasync(UpdateCategoryRequest request, CancellationToken cancellationToken);
    Task Removeasync(Guid id, CancellationToken cancellationToken);
}
