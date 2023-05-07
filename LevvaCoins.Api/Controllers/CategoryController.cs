using AutoMapper;
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
        readonly ICategoryServices _services;
        public CategoryController(ICategoryServices services, IMapper mapper)
        {
            _services = services;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAllAsync()
        {
            return Ok(await _services.GetAllCategoryAsync());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<ActionResult> PostAsync([FromBody] CreateCategoryDto body)
        {
            await _services.CreateCategoryAsync(body);
            return Created("", null);
        }

        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<ActionResult<CategoryDto>> GetByIdAsync([FromRoute] Guid id)
        {
            var category = await _services.GetCategoryByIdAsync(id);
            return Ok(category);
        }

        [HttpPut("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> PutAsync([FromRoute] Guid id, UpdateCategoryDto categoryDto)
        {
            await _services.UpdateCategoryAsync(id, categoryDto);
            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<ActionResult> DeleteAsync([FromRoute] Guid id)
        {
            await _services.DeleteCategoryAsync(id);
            return NoContent();
        }
    }
}
