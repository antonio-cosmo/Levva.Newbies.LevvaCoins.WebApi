using LevvaCoins.Application.Queries.Interfaces.Category;
using LevvaCoins.Application.Queries.Requests.Category;
using LevvaCoins.Application.Responses;
using LevvaCoins.Application.Services.Interfaces;

namespace LevvaCoins.Application.Queries.Handlers.Category;

public class GetAllCategoryHandler : IGetAllCategoryHandler
{
    private readonly ICategoryServices _categoryServices;

    public GetAllCategoryHandler(ICategoryServices categoryServices)
    {
        _categoryServices = categoryServices;
    }

    public async Task<IEnumerable<CategoryModelResponse>> Handle(GetAllCategoryRequest request,
        CancellationToken cancellationToken)
    {
        return await _categoryServices.GetAllAsync(cancellationToken);
    }
}