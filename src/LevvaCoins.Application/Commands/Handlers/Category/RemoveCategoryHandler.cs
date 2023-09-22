using LevvaCoins.Application.Commands.Interfaces.Category;
using LevvaCoins.Application.Commands.Requests.Category;
using LevvaCoins.Application.Services.Interfaces;

namespace LevvaCoins.Application.Commands.Handlers.Category;

public class RemoveCategoryHandler : IRemoveCategoryHandler
{
    private readonly ICategoryServices _categoryServices;

    public RemoveCategoryHandler(ICategoryServices categoryServices)
    {
        _categoryServices = categoryServices;
    }

    public async Task Handle(RemoveCategoryRequest request, CancellationToken cancellationToken)
    {
        await _categoryServices.RemoveAsync(request.Id, cancellationToken);
    }
}