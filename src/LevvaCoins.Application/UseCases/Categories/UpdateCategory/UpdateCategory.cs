using LevvaCoins.Application.Exceptions;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.SeedWork;

namespace LevvaCoins.Application.UseCases.Categories.UpdateCategory
{
    public class UpdateCategory : IUpdateCategory
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCategory(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateCategoryInput request, CancellationToken cancellationToken)
        {
            var category = await FindCategory(request.Id, cancellationToken);

            category.ChangeDescription(request.Description);

            await _unitOfWork.CategoryRepository.UpdateAsync(category, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
        }

        private async Task<Category> FindCategory(Guid id, CancellationToken cancellationToken)
        {
            return await _unitOfWork.CategoryRepository.GetAsync(id, cancellationToken)
                ?? throw new ModelNotFoundException("Essa categoria não existe.");
        }
    }
}
