using LevvaCoins.Application.Categories.Dtos;
using LevvaCoins.Application.Categories.Interfaces;
using LevvaCoins.Application.Common.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LevvaCoins.Api.Controllers
{
    [Authorize]
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        readonly ICategoryServices _categoryServices;
        public CategoryController(ICategoryServices services)
        {
            _categoryServices = services;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAllAsync() =>
            Ok(await _categoryServices.GetAllAsync());

        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<CategoryDto>> GetByIdAsync([FromRoute] Guid id) =>
            Ok(await _categoryServices.GetByIdAsync(id));

        [HttpPost]
        [ProducesResponseType(typeof(CategoryDto) ,StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> PostAsync([FromBody] CreateCategoryDto body) =>
            Created("", await _categoryServices.SaveAsync(body));

        [HttpPut("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> PutAsync([FromRoute] Guid id, [FromBody] UpdateCategoryDto categoryDto)
        {
            await _categoryServices.UpdateAsync(id, categoryDto);
            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> DeleteAsync([FromRoute] Guid id)
        {
            await _categoryServices.RemoveAsync(id);
            return NoContent();
        }
    }
}
