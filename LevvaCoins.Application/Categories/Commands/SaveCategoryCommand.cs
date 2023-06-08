using AutoMapper;
using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Interfaces.Repositories;
using MediatR;

namespace LevvaCoins.Application.Categories.Commands
{
    public class SaveCategoryCommand : IRequest<Category>
    {
        public string Description { get; set; } = string.Empty;

        public SaveCategoryCommand(string description)
        {
            Description = description;
        }
    }

    public class CreateCategoryCommandHandler : IRequestHandler<SaveCategoryCommand, Category>
    {
        readonly ICategoryRepository _categoryRepository;
        readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Category> Handle(SaveCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByDescriptionAsync(request.Description!);

            if (category is not null) throw new ModelNotFoundException("Uma categoria com esse nome já existe.");

            return await _categoryRepository.SaveAsync(_mapper.Map<Category>(request));
        }
    }
}
