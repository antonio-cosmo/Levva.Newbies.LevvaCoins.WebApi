using LevvaCoins.Application.Categories.Commands;
using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Interfaces.Repositories;
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
            try
            {
                var categoryExists = await _categoryRepository.GetByIdAsync(request.Id)
                    ?? throw new ModelNotFoundException("Essa categoria não existe.");

                categoryExists.Update(request.Description);
                categoryExists.Validate();

                await _categoryRepository.UpdateAsync(categoryExists);

            }catch (Exception)
            {
                throw;
            }
        }
    }
}
