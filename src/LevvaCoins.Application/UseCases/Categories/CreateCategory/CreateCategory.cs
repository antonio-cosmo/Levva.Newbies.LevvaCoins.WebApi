using AutoMapper;
using LevvaCoins.Application.Exceptions;
using LevvaCoins.Application.UseCases.Categories.Common;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Repositories;
using LevvaCoins.Domain.SeedWork;

namespace LevvaCoins.Application.UseCases.Categories.CreateCategory;
public class CreateCategory : ICreateCategory
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateCategory(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CategoryOutput> Handle(CreateCategoryInput request, CancellationToken cancellationToken)
    {
        await ValidateCategoryAlreadyExists(request.Description, cancellationToken);

        var newCategory = _mapper.Map<Category>(request);

        await _categoryRepository.InsertAsync(newCategory, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return CategoryOutput.FromDomain(newCategory);
    }
    private async Task ValidateCategoryAlreadyExists(string description, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByDescriptionAsync(description.ToLower(), cancellationToken);
        if (category is not null)
        {
            throw new ModelAlreadyExistsException("Uma categoria com esse nome já existe.");
        }
    }
}
