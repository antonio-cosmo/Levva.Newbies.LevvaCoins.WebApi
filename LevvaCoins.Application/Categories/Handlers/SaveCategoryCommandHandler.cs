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
            await ValidateCategoryAlreadyExists(request.Description);

            var newCategory = _mapper.Map<Category>(request);
            ValidateCategory(newCategory);

            return await _categoryRepository.SaveAsync(newCategory);
        }

        private async Task ValidateCategoryAlreadyExists(string description)
        {
            var category = await _categoryRepository.GetByDescriptionAsync(description.ToLower());
            if (category is not null)
            {
                throw new ModelAlreadyExistsException("Uma categoria com esse nome já existe.");
            }
        }
        private static void ValidateCategory(Category category)
        {
            if (!category.IsValid())
            {
                throw new DomainValidationException("Entidade inválida");
            }
        }
    }
}
