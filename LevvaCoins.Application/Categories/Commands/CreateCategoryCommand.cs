using AutoMapper;
using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Interfaces.Repositories;
using MediatR;

namespace LevvaCoins.Application.Categories.Commands
{
    public class CreateCategoryCommand : IRequest
    {
        public string Description { get; set; } = string.Empty;

        public CreateCategoryCommand(string description)
        {
            Description = description;
        }
    }

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
    {
        readonly ICategoryRepository _categoryRepository;
        readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryAlreadyExists = await _categoryRepository.GetByDescriptionAsync(request.Description!);
            if (categoryAlreadyExists != null) throw new ModelNotFoundException("Uma categoria com esse nome já existe.");

            var category = _mapper.Map<Category>(request);
            await _categoryRepository.SaveAsync(category);
        }
    }
}
