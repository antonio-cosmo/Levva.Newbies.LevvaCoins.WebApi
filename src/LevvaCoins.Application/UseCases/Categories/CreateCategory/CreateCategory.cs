using AutoMapper;
using LevvaCoins.Application.Exceptions;
using LevvaCoins.Application.UseCases.Categories.Common;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.SeedWork;

namespace LevvaCoins.Application.UseCases.Categories.CreateCategory;
public class CreateCategory : ICreateCategory
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategory(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CategoryModelOutput> Handle(CreateCategoryInput request, CancellationToken cancellationToken)
    {
        await ValidateCategoryAlreadyExists(request.Description, cancellationToken);

        var newCategory = new Category(
                request.Description
            );

        await _unitOfWork.CategoryRepository.InsertAsync(newCategory, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return CategoryModelOutput.FromDomain(newCategory);
    }
    private async Task ValidateCategoryAlreadyExists(string description, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.CategoryRepository.GetByDescriptionAsync(description, cancellationToken);
        if (category is not null)
        {
            throw new ModelAlreadyExistsException("Uma categoria com esse nome já existe.");
        }
    }
}
