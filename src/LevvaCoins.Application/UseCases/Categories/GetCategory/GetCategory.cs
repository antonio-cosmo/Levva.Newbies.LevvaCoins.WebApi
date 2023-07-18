using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevvaCoins.Application.Exceptions;
using LevvaCoins.Application.UseCases.Categories.Common;
using LevvaCoins.Domain.Repositories;

namespace LevvaCoins.Application.UseCases.Categories.GetCategory;
public class GetCategory : IGetCategory
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategory(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<CategoryOutput> Handle(GetCategoryInput request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetAsync(request.Id, cancellationToken)
            ?? throw new ModelNotFoundException("Categoria não existe.");

        return CategoryOutput.FromDomain(category);
    }
}
