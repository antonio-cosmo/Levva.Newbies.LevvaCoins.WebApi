using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Interfaces.Repositories;
using MediatR;

namespace LevvaCoins.Application.Categories.Commands
{
    public class DeleteCategoryCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteCategoryCommand(Guid id)
        {
            Id = id;
        }
    }

    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryAlreadExist = await _categoryRepository.GetByIdAsync(request.Id);
            if (categoryAlreadExist is null) throw new ModelNotFoundException("Essa categoria não existe.");
            
            await _categoryRepository.RemoveAsync(categoryAlreadExist);
        }
    }
}
