using LevvaCoins.Application.Commands.Requests.Category;
using LevvaCoins.Application.Common;
using LevvaCoins.Application.Responses;
using LevvaCoins.Application.Services.Interfaces;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.SeedWork;

namespace LevvaCoins.Application.Services;

public class CategoryServices : ICategoryServices
{
    private readonly NotificationContext _notificationContext;
    private readonly IUnitOfWork _unitOfWork;

    public CategoryServices(IUnitOfWork unitOfWork, NotificationContext notificationContext)
    {
        _unitOfWork = unitOfWork;
        _notificationContext = notificationContext;
    }

    public async Task<IEnumerable<CategoryModelResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        var categories = await _unitOfWork.CategoryRepository.GetAllAsync(cancellationToken);
        return CategoryModelResponse.FromDomain(categories);
    }

    public async Task<CategoryModelResponse> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id, cancellationToken);
        
        if (category is not null) return CategoryModelResponse.FromDomain(category);
        
        _notificationContext.AddNotification("Exception", "Categoria não existe.");
        return null;

    }

    public async Task<CategoryModelResponse?> InsertAsync(CreateCategoryRequest request,
        CancellationToken cancellationToken)
    {
        var categoryAlreadyExists = await ValidateCategoryAlreadyExists(request.Description, cancellationToken);
        
        if (categoryAlreadyExists)
        {
            _notificationContext.AddNotification("Exception", "Uma categoria com esse nome já existe");
            return null;
        }
        
        var newCategory = new Category(
            request.Description
        );
        
        if (!newCategory.IsValid)
        {
            _notificationContext.AddNotifications(newCategory.Notifications);
            return null;
        }

        await _unitOfWork.CategoryRepository.InsertAsync(newCategory, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        return CategoryModelResponse.FromDomain(newCategory);
    }

    public async Task RemoveAsync(Guid id, CancellationToken cancellationToken)
    {
        var category = await FindCategory(id, cancellationToken);
        if (category is null)
        {
            _notificationContext.AddNotification("Exception", "Essa categoria não existe.");
            return;
        }
        await _unitOfWork.CategoryRepository.RemoveAsync(category, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
    }

    public async Task UpdateAsync(UpdateCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = await FindCategory(request.Id, cancellationToken);
        
        if (category is null)
        {
            _notificationContext.AddNotification("Exception", "Essa categoria não existe.");
            return;
        }
        
        category.ChangeDescription(request.Description);

        await _unitOfWork.CategoryRepository.UpdateAsync(category, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
    }

    private async Task<bool> ValidateCategoryAlreadyExists(string description, CancellationToken cancellationToken)
    {
        var category =
            await _unitOfWork.CategoryRepository.GetByPredicateAsync(x => x.Description == description.ToUpper(),
                cancellationToken);
        return (category is not null);
    }

    private async Task<Category?> FindCategory(Guid id, CancellationToken cancellationToken)
    {
        return await _unitOfWork.CategoryRepository.GetByIdAsync(id, cancellationToken);
    }
}