using LevvaCoins.Application.Exceptions;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.SeedWork;

namespace LevvaCoins.Application.UseCases.Categories.RemoveCategory
{
    public class RemoveCategory : IRemoveCategory
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveCategory(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveCategoryInput request, CancellationToken cancellationToken)
        {
            var category = await FindCategory(request.Id, cancellationToken);

            await _unitOfWork.CategoryRepository.RemoveAsync(category, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
        private async Task<Category> FindCategory(Guid id, CancellationToken cancellationToken)
        {
            return await _unitOfWork.CategoryRepository.GetAsync(id, cancellationToken)
                ?? throw new ModelNotFoundException("Essa categoria não existe.");
        }
    }
}
