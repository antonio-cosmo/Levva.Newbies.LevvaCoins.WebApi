using LevvaCoins.Application.Categories.Commands;
using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Repositories;
using LevvaCoins.Domain.ValueObjects;
using MediatR;

namespace LevvaCoins.Application.Categories.Handlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await GetCategoryById(request.Id);

            var description = new Description(request.Description);
            category.ChangeDescription(description);

            ValidateCategory(category);

            await _categoryRepository.UpdateAsync(category);
        }

        private async Task<Category> GetCategoryById(Guid id)
        {
            return await _categoryRepository.GetAsync(id) ?? throw new ModelNotFoundException("Essa categoria não existe.");
        }

        private static void ValidateCategory(Category category)
        {
            if (!category.IsValid)
            {
                throw new DomainValidationException("Entidade invalida");
            }
        }
    }
}
