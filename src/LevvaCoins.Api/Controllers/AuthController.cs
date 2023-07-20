using LevvaCoins.Api.Common;
using LevvaCoins.Application.UseCases.Users.AuthenticateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LevvaCoins.Api.Controllers
{
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
        public async Task<ActionResult<AuthenticateUserOutput>> PostAuthAsync([FromBody] AuthenticateUserInput authenticateUser, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(authenticateUser, cancellationToken));
        }
    }
}
