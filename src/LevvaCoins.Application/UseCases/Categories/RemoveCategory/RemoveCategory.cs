using LevvaCoins.Application.Exceptions;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Repositories;
using LevvaCoins.Domain.SeedWork;
using MediatR;

namespace LevvaCoins.Application.UseCases.Categories.RemoveCategory
{
    public class RemoveCategory : IRemoveCategory
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveCategory(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveCategoryInput request, CancellationToken cancellationToken)
        {
            var category = await FindCategory(request.Id, cancellationToken);

            await _categoryRepository.RemoveAsync(category, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
        private async Task<Category> FindCategory(Guid id, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetAsync(id, cancellationToken)
                ?? throw new ModelNotFoundException("Essa categoria não existe.");
        }
    }
}
