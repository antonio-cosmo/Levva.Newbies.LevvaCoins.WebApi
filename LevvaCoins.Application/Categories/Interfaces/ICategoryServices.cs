using LevvaCoins.Application.Categories.Dtos;

namespace LevvaCoins.Application.Categories.Interfaces
{
    public interface ICategoryServices
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<CategoryDto> SaveAsync(SaveCategoryDto categoryDto);
        Task UpdateAsync(Guid id, UpdateCategoryDto categoryDto);
        Task RemoveAsync(Guid id);
        Task<CategoryDto> GetByIdAsync(Guid id);
    }
}
