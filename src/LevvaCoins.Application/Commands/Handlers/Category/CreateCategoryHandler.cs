using LevvaCoins.Application.Commands.Interfaces.Category;
using LevvaCoins.Application.Commands.Requests.Category;
using LevvaCoins.Application.Responses;
using LevvaCoins.Application.Services.Interfaces;

namespace LevvaCoins.Application.Commands.Handlers.Category;

public class CreateCategoryHandler : ICreateCategoryHandler
{
    private readonly ICategoryServices _categoryServices;

    public CreateCategoryHandler(ICategoryServices categoryServices)
    {
        _categoryServices = categoryServices;
    }

    public async Task<CategoryModelResponse?> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        var createCategory = new CreateCategoryRequest(request.Description);
        return await _categoryServices.InsertAsync(createCategory, cancellationToken);
    }
}