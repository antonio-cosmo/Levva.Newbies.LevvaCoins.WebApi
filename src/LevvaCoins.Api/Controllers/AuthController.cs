using LevvaCoins.Api.Common;
using LevvaCoins.Application.UseCases.Users.UserAuthenticate;
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
        [ProducesResponseType(typeof(ErrorResponseModelOutput), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UserAuthenticateModelOutput>> PostAuthAsync([FromBody] UserAuthenticateInput authenticateUser, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(authenticateUser, cancellationToken));
        }
    }
}
