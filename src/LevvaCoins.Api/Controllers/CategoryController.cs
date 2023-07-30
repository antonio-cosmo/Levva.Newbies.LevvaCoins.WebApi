using LevvaCoins.Api.ApiModels.Category;
using LevvaCoins.Api.Common;
using LevvaCoins.Application.Services.Dtos.Category;
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
        [ProducesResponseType(typeof(ErrorResponseModelOutput), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<CategoryModelResponse>>> GetAllAsync(CancellationToken cancellationToken) =>
            Ok(await _mediator.Send(new GetAllCategory(), cancellationToken));

        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseModelOutput), 400)]
        [ProducesResponseType(typeof(ErrorResponseModelOutput), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<CategoryModelResponse>> GetByIdAsync([FromRoute] Guid id, CancellationToken cancellationToken) =>
            Ok(await _mediator.Send(new GetCategory(id), cancellationToken));

        [HttpPost]
        [ProducesResponseType(typeof(CategoryModelResponse) ,StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponseModelOutput), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModelOutput), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> PostAsync([FromBody] CreateCategory body, CancellationToken cancellationToken) =>
            Created("", await _mediator.Send(body, cancellationToken));

        [HttpPut("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponseModelOutput), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModelOutput), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> PutAsync([FromRoute] Guid id, [FromBody] UpdateCategoryApiInput updateCategoryInput,CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateCategory(
                    id,
                    updateCategoryInput.Description
                ), cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponseModelOutput), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseModelOutput), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> DeleteAsync([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new RemoveCategory(id), cancellationToken);
            return NoContent();
        }
    }
}
