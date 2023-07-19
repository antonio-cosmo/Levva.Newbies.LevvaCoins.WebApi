using LevvaCoins.Api.ApiModel.User;
using LevvaCoins.Application.Common;
using LevvaCoins.Application.UseCases.Users.Common;
using LevvaCoins.Application.UseCases.Users.CreateUser;
using LevvaCoins.Application.UseCases.Users.GetAllUser;
using LevvaCoins.Application.UseCases.Users.GetUser;
using LevvaCoins.Application.UseCases.Users.RemoveUser;
using LevvaCoins.Application.UseCases.Users.UpdateUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LevvaCoins.Api.Controllers
{
    [Authorize]
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
        public async Task<ActionResult<IEnumerable<UserOutput>>> GetAllAsync() =>
            Ok(await _mediator.Send(new GetAllUsersInput()));

        [HttpGet("{userId:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UserOutput>> GetByIdAsync([FromRoute] Guid userId) =>
            Ok(await _mediator.Send(new GetUserInput(userId)));

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserOutput>> PostAsync([FromBody] CreateUserInput body) =>
            Created("", await _mediator.Send(body));

        [HttpPut("{userId:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> PutAsync([FromRoute] Guid userId, [FromBody] UpdateUserApiInput body)
        {
            await _mediator.Send(new UpdateUserInput(
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
            await _mediator.Send(new RemoveUserInput(userId));
            return NoContent();
        }
    }
}
