using LevvaCoins.Api.Common;
using LevvaCoins.Application.Commands.Requests.User;
using LevvaCoins.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LevvaCoins.Api.Controllers.V1;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<UserAuthenticateModelResponse>> PostAuthAsync(
        [FromBody] UserAuthenticateRequest request, CancellationToken cancellationToken)
    {
        return Ok(await _mediator.Send(request, cancellationToken));
    }
}