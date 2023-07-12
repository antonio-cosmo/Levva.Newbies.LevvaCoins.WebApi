using LevvaCoins.Application.Users.Dtos;
using LevvaCoins.Application.Users.Interfaces;
using LevvaCoins.Application.Common.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LevvaCoins.Api.Controllers
{
    [Authorize]
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUserServices _accountServices;
        public UserController(IUserServices accountServices)
        {
            _accountServices = accountServices;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllAsync() => 
            Ok(await _accountServices.GetAllAsync());
        

        [HttpGet("{userId:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UserDto>> GetByIdAsync([FromRoute] Guid userId) =>
            Ok(await _accountServices.GetByIdAsync(userId));
        

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> PostAsync([FromBody] CreateUserDto body) =>
            Created("", await _accountServices.SaveAsync(body));
        

        [HttpPut("{userId:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> PutAsync([FromRoute] Guid userId, [FromBody] UpdateUserDto body)
        {
            await _accountServices.UpdateAsync(userId, body);
            return NoContent();
        }


        [HttpDelete("{userId:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid userId)
        {
            await _accountServices.RemoveAsync(userId);
            return NoContent();
        }
    }
}
