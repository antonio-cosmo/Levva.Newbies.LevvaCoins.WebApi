using LevvaCoins.Application.Categories.Dtos;
using LevvaCoins.Application.Categories.Interfaces;
using LevvaCoins.Application.Common.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LevvaCoins.Api.Controllers
{
    [Authorize]
    [Route("category")]
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
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAllAsync()
        {

            return Ok(await _categoryServices.GetAllCategoryAsync());
        }

        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<ActionResult<CategoryDto>> GetByIdAsync([FromRoute] Guid id)
        {

            var category = await _categoryServices.GetCategoryByIdAsync(id);

            return Ok(category);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<ActionResult> PostAsync([FromBody] CreateCategoryDto body)
        {
            await _categoryServices.CreateCategoryAsync(body);
            return Created("", null);
        }

        [HttpPut("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> PutAsync([FromRoute] Guid id, [FromBody] UpdateCategoryDto categoryDto)
        {
            await _categoryServices.UpdateCategoryAsync(id, categoryDto);
            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<ActionResult> DeleteAsync([FromRoute] Guid id)
        {
            
            await _categoryServices.DeleteCategoryAsync(id);
            return NoContent();
        }
    }
}
