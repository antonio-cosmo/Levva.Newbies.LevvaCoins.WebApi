using LevvaCoins.Application.UseCases.Categories.Common;
using LevvaCoins.Domain.Repositories;

namespace LevvaCoins.Application.UseCases.Categories.GetAllCategory;
internal class GetAllCategory : IGetAllCategory
{
    private readonly ICategoryRepository _categoryRepository;

    public GetAllCategory(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<CategoryOutput>> Handle(GetAllCategoryInput request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetAllAsync(cancellationToken);
        return CategoryOutput.FromDomain(categories);
    }
}
