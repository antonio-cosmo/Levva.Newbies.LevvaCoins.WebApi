using LevvaCoins.Application.Exceptions;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Repositories;
using LevvaCoins.Domain.SeedWork;
using LevvaCoins.Domain.ValueObjects;

namespace LevvaCoins.Application.UseCases.Categories.UpdateCategory
{
    public class UpdateCategory : IUpdateCategory
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCategory(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateCategoryInput request, CancellationToken cancellationToken)
        {
            var category = await FindCategory(request.Id, cancellationToken);

            //var description = new Description(request.Description);
            category.ChangeDescription(request.Description);

            await _categoryRepository.UpdateAsync(category, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
        }

        private async Task<Category> FindCategory(Guid id, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetAsync(id, cancellationToken)
                ?? throw new ModelNotFoundException("Essa categoria não existe.");
        }
    }
}
