using AutoMapper;
using LevvaCoins.Application.Categories.Commands;
using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Interfaces.Repositories;
using MediatR;

namespace LevvaCoins.Application.Categories.Handlers
{
    public class SaveCategoryCommandHandler : IRequestHandler<SaveCategoryCommand, Category>
    {
        readonly ICategoryRepository _categoryRepository;
        readonly IMapper _mapper;

        public SaveCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Category> Handle(SaveCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByDescriptionAsync(request.Description!);

            if (category is not null) throw new ModelAlreadyExistsException("Uma categoria com esse nome já existe.");

            return await _categoryRepository.SaveAsync(_mapper.Map<Category>(request));
        }
    }
}
