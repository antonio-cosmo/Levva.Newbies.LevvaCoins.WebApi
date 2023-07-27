using LevvaCoins.Application.Exceptions;
using LevvaCoins.Application.UseCases.Categories.Common;
using LevvaCoins.Domain.SeedWork;

namespace LevvaCoins.Application.UseCases.Categories.GetCategory;
public class GetCategory : IGetCategory
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCategory(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CategoryModelOutput> Handle(GetCategoryInput request, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.CategoryRepository.GetAsync(request.Id, cancellationToken)
            ?? throw new ModelNotFoundException("Categoria não existe.");

        return CategoryModelOutput.FromDomain(category);
    }
}
