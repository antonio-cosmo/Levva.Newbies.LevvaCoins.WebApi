using LevvaCoins.Api.ApiModels.Category;
using LevvaCoins.Api.Common;
using LevvaCoins.Application.Commands.Requests.Category;
using LevvaCoins.Application.Queries.Requests.Category;
using LevvaCoins.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LevvaCoins.Api.Controllers.V1;

//[Authorize]
[Route("api/category")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<IEnumerable<CategoryModelResponse>>> GetAllAsync(CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetAllCategoryRequest(), cancellationToken));
    }

    [HttpGet("{id:Guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<CategoryModelResponse>> GetByIdAsync([FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(new GetCategoryRequest(id), cancellationToken));
    }

    [HttpPost]
    [ProducesResponseType(typeof(CategoryModelResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> PostAsync([FromBody] CreateCategoryRequest body,
        CancellationToken cancellationToken)
    {
        return Created("", await _mediator.Send(body, cancellationToken));
    }

    [HttpPut("{id:Guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> PutAsync([FromRoute] Guid id,
        [FromBody] UpdateCategoryApiInput updateCategoryInput, CancellationToken cancellationToken)
    {
        await _mediator.Send(new UpdateCategoryRequest(
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
        await _mediator.Send(new RemoveCategoryRequest(id), cancellationToken);
        return NoContent();
    }
}