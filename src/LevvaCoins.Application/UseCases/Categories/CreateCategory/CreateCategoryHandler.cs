using LevvaCoins.Application.Services.Dtos.Category;
using LevvaCoins.Application.Services.Interfaces;

namespace LevvaCoins.Application.UseCases.Categories.CreateCategory;
public class CreateCategoryHandler : ICreateCategoryHandler
{
    private readonly ICategoryServices _categoryServices;

    public CreateCategoryHandler(ICategoryServices categoryServices)
    {
        _categoryServices = categoryServices;
    }

    public async Task<CategoryModelResponse> Handle(CreateCategory request, CancellationToken cancellationToken)
    {
        var createCategory = new CreateCategoryRequest(request.Description);
        return await _categoryServices.InsertAsync(createCategory, cancellationToken);
    }

}
