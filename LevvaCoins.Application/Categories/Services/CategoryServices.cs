using AutoMapper;
using LevvaCoins.Application.Categories.Dtos;
using LevvaCoins.Application.Categories.Interfaces;
using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Interfaces.Repositories;

namespace LevvaCoins.Application.Categories.Services
{
    public class CategoryServices: ICategoryServices
    {
        readonly ICategoryRepository _categoryRepository;
        readonly IMapper _mapper;
        public CategoryServices(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto categoryDto)
        {
            var categoryAlreadyExists = await _categoryRepository.GetByDescriptionAsync(categoryDto.Description);
            if (categoryAlreadyExists != null) throw new ModelNotFoundException("Uma categoria com esse nome já existe.");

            var category = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.SaveAsync(category);
        }

        public async Task DeleteCategoryAsync(Guid id)
        {
            var success = await _categoryRepository.DeleteByIdAsync(id);
            if (!success) throw new ModelNotFoundException("Essa categoria não existe.");
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoryAsync()
        {
            var categoryList = await _categoryRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<CategoryDto>>(categoryList);
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null) throw new ModelNotFoundException("Essa categoria não existe");
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task UpdateCategoryAsync(Guid id, UpdateCategoryDto categoryDto)
        {
            var categoryAlreadyExists = await _categoryRepository.GetByIdAsync(id);
            if (categoryAlreadyExists == null) throw new ModelNotFoundException("Essa categoria não existe");

            categoryAlreadyExists.Description = categoryDto.Description;
            await _categoryRepository.UpdateAsync(categoryAlreadyExists);
        }
    }
}
