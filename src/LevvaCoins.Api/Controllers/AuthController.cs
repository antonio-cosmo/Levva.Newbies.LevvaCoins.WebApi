using LevvaCoins.Application.Common;
using LevvaCoins.Application.UseCases.Users.Dtos;
using LevvaCoins.Application.UseCases.Users.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LevvaCoins.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IAuthenticateService _authenticateService;

        public AuthController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<LoginResponseDto>> PostAuthAsync([FromBody] LoginDto loginDto)
        {
            return Ok(await _authenticateService.GenerateToken(loginDto));
        }
    }
}
