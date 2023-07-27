using LevvaCoins.Application.UseCases.Categories.Common;
using LevvaCoins.Domain.SeedWork;

namespace LevvaCoins.Application.UseCases.Categories.GetAllCategory;
internal class GetAllCategory : IGetAllCategory
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCategory(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<CategoryModelOutput>> Handle(GetAllCategoryInput request, CancellationToken cancellationToken)
    {
        var categories = await _unitOfWork.CategoryRepository.GetAllAsync(cancellationToken);
        return CategoryModelOutput.FromDomain(categories);
    }
}
