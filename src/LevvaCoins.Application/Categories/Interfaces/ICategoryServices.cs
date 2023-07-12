using LevvaCoins.Application.Categories.Dtos;

namespace LevvaCoins.Application.Categories.Interfaces
{
    public interface ICategoryServices
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<CategoryDto> SaveAsync(CreateCategoryDto createCategoryDto);
        Task UpdateAsync(Guid id, UpdateCategoryDto updateCategoryDto);
        Task RemoveAsync(Guid id);
        Task<CategoryDto> GetByIdAsync(Guid id);
    }
}
