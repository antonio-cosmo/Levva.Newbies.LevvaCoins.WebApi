using LevvaCoins.Api.ApiModels.User;
using LevvaCoins.Api.Common;
using LevvaCoins.Application.Commands.Requests.User;
using LevvaCoins.Application.Queries.Requests.User;
using LevvaCoins.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LevvaCoins.Api.Controllers.V1;

// [Authorize]
[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<IEnumerable<UserModelResponse>>> GetAllAsync()
    {
        return Ok(await _mediator.Send(new GetAllUsersRequest()));
    }

    [HttpGet("{userId:Guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<UserModelResponse>> GetByIdAsync([FromRoute] Guid userId)
    {
        return Ok(await _mediator.Send(new GetUserRequest(userId)));
    }

    [AllowAnonymous]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<UserModelResponse>> PostAsync([FromBody] CreateUserRequest body)
    {
        return Created("", await _mediator.Send(body));
    }

    [HttpPut("{userId:Guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult> PutAsync([FromRoute] Guid userId, [FromBody] UpdateUserApiInput body)
    {
        await _mediator.Send(new UpdateUserRequest(
            userId,
            body.Name,
            body.Avatar
        ));
        return NoContent();
    }

    [HttpDelete("{userId:Guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid userId)
    {
        await _mediator.Send(new RemoveUserRequest(userId));
        return NoContent();
    }
}