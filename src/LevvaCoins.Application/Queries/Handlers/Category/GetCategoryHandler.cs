using LevvaCoins.Application.Queries.Interfaces.Category;
using LevvaCoins.Application.Queries.Requests.Category;
using LevvaCoins.Application.Responses;
using LevvaCoins.Application.Services.Interfaces;

namespace LevvaCoins.Application.Queries.Handlers.Category;

public class GetCategoryHandler : IGetCategoryHandler
{
    private readonly ICategoryServices _categoryServices;

    public GetCategoryHandler(ICategoryServices categoryServices)
    {
        _categoryServices = categoryServices;
    }

    public async Task<CategoryModelResponse> Handle(GetCategoryRequest request, CancellationToken cancellationToken)
    {
        return await _categoryServices.GetAsync(request.Id, cancellationToken);
    }
}