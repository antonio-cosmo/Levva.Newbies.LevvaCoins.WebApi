using LevvaCoins.Application.Services.Dtos.Category;
using LevvaCoins.Application.Services.Interfaces;

namespace LevvaCoins.Application.UseCases.Categories.GetAllCategory;
internal class GetAllCategoryHandler : IGetAllCategoryHandler
{
    private readonly ICategoryServices _categoryServices;

    public GetAllCategoryHandler(ICategoryServices categoryServices)
    {
        _categoryServices = categoryServices;
    }

    public async Task<IEnumerable<CategoryModelResponse>> Handle(GetAllCategory request, CancellationToken cancellationToken)
    {
        return await _categoryServices.GetallAsync(cancellationToken);
    }
}
