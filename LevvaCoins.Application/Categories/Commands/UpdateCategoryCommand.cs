using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Interfaces.Repositories;
using MediatR;

namespace LevvaCoins.Application.Categories.Commands
{
    public class UpdateCategoryCommand : IRequest
    {
        public string Description { get; set; } = string.Empty;
        public Guid Id { get; set; }

        public UpdateCategoryCommand(string description, Guid id)
        {
            Description = description;
            Id = id;
        }
    }

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);
            if(category is null) throw new ModelNotFoundException("Essa categoria não existe.");

            category.Update(request.Description);
            await _categoryRepository.UpdateAsync(category);
        }
    }
}
