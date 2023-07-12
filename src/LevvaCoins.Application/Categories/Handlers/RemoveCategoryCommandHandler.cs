using LevvaCoins.Application.Categories.Commands;
using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Repositories;
using MediatR;

namespace LevvaCoins.Application.Categories.Handlers
{
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand>
    {
        readonly ICategoryRepository _categoryRepository;

        public RemoveCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetAsync(request.Id)
                ?? throw new ModelNotFoundException("Essa categoria não existe.");

            await _categoryRepository.RemoveAsync(category);
        }
    }
}
