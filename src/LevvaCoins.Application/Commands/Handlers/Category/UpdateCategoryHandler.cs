using LevvaCoins.Application.Commands.Interfaces.Category;
using LevvaCoins.Application.Commands.Requests.Category;
using LevvaCoins.Application.Services.Interfaces;

namespace LevvaCoins.Application.Commands.Handlers.Category;

public class UpdateCategoryHandler : IUpdateCategoryHandler
{
    private readonly ICategoryServices _categoryServices;

    public UpdateCategoryHandler(ICategoryServices categoryServices)
    {
        _categoryServices = categoryServices;
    }

    public async Task Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
    {
        var updateRequest = new UpdateCategoryRequest(request.Id, request.Description);
        await _categoryServices.UpdateAsync(updateRequest, cancellationToken);
    }
}