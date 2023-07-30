using LevvaCoins.Application.Services.Dtos.Category;
using LevvaCoins.Application.Services.Interfaces;

namespace LevvaCoins.Application.UseCases.Categories.GetCategory;
public class GetCategoryHandler : IGetCategoryHandler
{
    private readonly ICategoryServices _categoryServices;

    public GetCategoryHandler(ICategoryServices categoryServices)
    {
        _categoryServices = categoryServices;
    }

    public async Task<CategoryModelResponse> Handle(GetCategory request, CancellationToken cancellationToken)
    {
        return await _categoryServices.GetAsync(request.Id, cancellationToken);
    }
}
