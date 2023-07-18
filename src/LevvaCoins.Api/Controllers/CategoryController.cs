using LevvaCoins.Api.ApiModel.Category;
using LevvaCoins.Application.Categories.UseCases.GetAllCategory;
using LevvaCoins.Application.Categories.UseCases.GetCategory;
using LevvaCoins.Application.Categories.UseCases.RemoveCategory;
using LevvaCoins.Application.Categories.UseCases.UpdateCategory;
using LevvaCoins.Application.Common;
using LevvaCoins.Application.UseCases.Categories.Common;
using LevvaCoins.Application.UseCases.Categories.CreateCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LevvaCoins.Api.Controllers
{
    //[Authorize]
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<CategoryOutput>>> GetAllAsync() =>
            Ok(await _mediator.Send(new GetAllCategoryInput()));

        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<CategoryOutput>> GetByIdAsync([FromRoute] Guid id) =>
            Ok(await _mediator.Send(new GetCategoryInput(id)));

        [HttpPost]
        [ProducesResponseType(typeof(CategoryOutput) ,StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> PostAsync([FromBody] CreateCategoryInput body) =>
            Created("", await _mediator.Send(body));

        [HttpPut("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> PutAsync([FromRoute] Guid id, [FromBody] UpdateCategoryApiInput updateCategoryInput)
        {
            await _mediator.Send(new UpdateCategoryInput(
                    id,
                    updateCategoryInput.Description
                ));
            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> DeleteAsync([FromRoute] Guid id)
        {
            await _mediator.Send(new RemoveCategoryInput(id));
            return NoContent();
        }
    }
}
