using LevvaCoins.Api.ApiModels.Transaction;
using LevvaCoins.Api.Common;
using LevvaCoins.Application.Commands.Requests.Transaction;
using LevvaCoins.Application.Extensions;
using LevvaCoins.Application.Queries.Requests.Transaction;
using LevvaCoins.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LevvaCoins.Api.Controllers.V1;

[Authorize]
[ApiController]
[Route("api/transaction")]
public class TransactionController : ControllerBase
{
    private readonly IMediator _mediator;

    public TransactionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<IEnumerable<TransactionDetailsModelResponse>>> GetAllTransactionsAsync()
    {
        var userId = User.GetUserId();

        return Ok(await _mediator.Send(new GetAllTransactionsRequest(userId)));
    }

    [HttpGet("search")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<IEnumerable<TransactionDetailsModelResponse>>>
        SearchAllTransactionsByDescriptionAsync([FromQuery] string query)
    {
        var userId = User.GetUserId();
        return Ok(await _mediator.Send(new GetTransactionsByDescriptionRequest(userId, query)));
    }

    [HttpGet("{id:Guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<TransactionModelResponse>> GetByIdAsync([FromRoute] Guid id)
    {
        return Ok(await _mediator.Send(new GetTransactionRequest(id)));
    }

    [HttpPost]
    [ProducesResponseType(typeof(TransactionDetailsModelResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> PostAsync([FromBody] CreateTransactionApiInput body)
    {
        var userId = User.GetUserId();
        var transaction = await _mediator.Send(new CreateTransactionRequest(
            body.Description,
            body.Amount,
            body.Type,
            body.CategoryId,
            userId
        ));

        return Created("", transaction);
    }

    [HttpPut("{id:Guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> PutAsync([FromRoute] Guid id, [FromBody] UpdateTransactionApiInput body)
    {
        await _mediator.Send(new UpdateTransactionRequest(
            id,
            body.Description,
            body.Amount,
            body.Type,
            body.CategoryId
        ));
        return NoContent();
    }

    [HttpDelete("{id:Guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        await _mediator.Send(new RemoveTransactionRequest(id));

        return NoContent();
    }
}