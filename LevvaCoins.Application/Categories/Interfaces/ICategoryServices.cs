using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevvaCoins.Application.Categories.Dtos;

namespace LevvaCoins.Application.Categories.Interfaces
{
    public interface ICategoryServices
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDto categoryDto);
        Task UpdateCategoryAsync(Guid id, UpdateCategoryDto categoryDto);
        Task DeleteCategoryAsync(Guid id);
        Task<CategoryDto> GetCategoryByIdAsync(Guid id);
    }
}
