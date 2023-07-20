using LevvaCoins.Api.ApiModel.Category;
using LevvaCoins.Api.Common;
using LevvaCoins.Application.UseCases.Categories.Common;
using LevvaCoins.Application.UseCases.Categories.CreateCategory;
using LevvaCoins.Application.UseCases.Categories.GetAllCategory;
using LevvaCoins.Application.UseCases.Categories.GetCategory;
using LevvaCoins.Application.UseCases.Categories.RemoveCategory;
using LevvaCoins.Application.UseCases.Categories.UpdateCategory;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LevvaCoins.Api.Controllers
{
    [Authorize]
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
        public async Task<ActionResult<IEnumerable<CategoryOutput>>> GetAllAsync(CancellationToken cancellationToken) =>
            Ok(await _mediator.Send(new GetAllCategoryInput(), cancellationToken));

        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<CategoryOutput>> GetByIdAsync([FromRoute] Guid id, CancellationToken cancellationToken) =>
            Ok(await _mediator.Send(new GetCategoryInput(id), cancellationToken));

        [HttpPost]
        [ProducesResponseType(typeof(CategoryOutput) ,StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> PostAsync([FromBody] CreateCategoryInput body, CancellationToken cancellationToken) =>
            Created("", await _mediator.Send(body, cancellationToken));

        [HttpPut("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> PutAsync([FromRoute] Guid id, [FromBody] UpdateCategoryApiInput updateCategoryInput,CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateCategoryInput(
                    id,
                    updateCategoryInput.Description
                ), cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> DeleteAsync([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new RemoveCategoryInput(id), cancellationToken);
            return NoContent();
        }
    }
}
