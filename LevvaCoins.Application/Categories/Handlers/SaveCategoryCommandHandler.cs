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
            try
            {
                var categoryExists = await _categoryRepository.GetByDescriptionAsync(request.Description.ToLower());
                if (categoryExists is not null)
                    throw new ModelAlreadyExistsException("Uma categoria com esse nome já existe.");
                
                var newCategory = _mapper.Map<Category>(request);
                newCategory.Validate();

                return await _categoryRepository.SaveAsync(newCategory);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
