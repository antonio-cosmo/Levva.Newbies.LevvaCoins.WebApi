using LevvaCoins.Application.Exceptions;
using LevvaCoins.Application.Services.Dtos.Category;
using LevvaCoins.Application.Services.Interfaces;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.SeedWork;

namespace LevvaCoins.Application.Services;
public class CategoryServices : ICategoryServices
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryServices(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<CategoryModelResponse>> GetallAsync(CancellationToken cancellationToken)
    {
        var categories = await _unitOfWork.CategoryRepository.GetAllAsync(cancellationToken);
        return CategoryModelResponse.FromDomain(categories);
    }
    public async Task<CategoryModelResponse> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.CategoryRepository.GetAsync(id, cancellationToken)
            ?? throw new ModelNotFoundException("Categoria não existe.");

        return CategoryModelResponse.FromDomain(category);
    }
    public async Task<CategoryModelResponse> InsertAsync(CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        await ValidateCategoryAlreadyExists(request.Description, cancellationToken);
        var newCategory = new Category(
        request.Description
            );

        await _unitOfWork.CategoryRepository.InsertAsync(newCategory, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return CategoryModelResponse.FromDomain(newCategory);
    }
    public async Task Removeasync(Guid id, CancellationToken cancellationToken)
    {
        var category = await FindCategory(id, cancellationToken);

        await _unitOfWork.CategoryRepository.RemoveAsync(category, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
    }
    public async Task Updateasync(UpdateCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = await FindCategory(request.Id, cancellationToken);

        category.ChangeDescription(request.Description);

        await _unitOfWork.CategoryRepository.UpdateAsync(category, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
    }
    private async Task ValidateCategoryAlreadyExists(string description, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.CategoryRepository.GetByDescriptionAsync(description, cancellationToken);
        if (category is not null)
        {
            throw new ModelAlreadyExistsException("Uma categoria com esse nome já existe.");
        }
    }
    private async Task<Category> FindCategory(Guid id, CancellationToken cancellationToken)
    {
        return await _unitOfWork.CategoryRepository.GetAsync(id, cancellationToken)
            ?? throw new ModelNotFoundException("Essa categoria não existe.");
    }
}
