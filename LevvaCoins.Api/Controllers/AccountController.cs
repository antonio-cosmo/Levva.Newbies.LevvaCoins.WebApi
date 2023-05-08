using LevvaCoins.Application.Accounts.Dtos;
using LevvaCoins.Application.Accounts.Interfaces;
using LevvaCoins.Application.Common.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LevvaCoins.Api.Controllers
{
    [Route("user")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        readonly IAccountServices _accountServices;
        public AccountController(IAccountServices accountServices)
        {
            _accountServices = accountServices;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AccountDto>>> GetAllAsync()
        {
            return Ok(await _accountServices.GetAllAccountAsync());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PostAsync([FromBody] CreateAccountDto body)
        {
            await _accountServices.CreateAccountAsync(body);
            return Created("", null);
        }

        [Authorize]
        [HttpGet("{userId:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AccountDto>> GetByIdAsync([FromRoute] Guid userId)
        {
            var account = await _accountServices.GetAccountByIdAsync(userId);
            return Ok(account);
        }

        [Authorize]
        [HttpPut("{userId:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PutAsync([FromRoute] Guid userId, [FromBody] UpdateAccountDto body)
        {
            await _accountServices.UpdateAccountAsync(userId, body);
            return NoContent();
        }


        [Authorize]
        [HttpDelete("{userId:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid userId)
        {
            await _accountServices.DeleteAccountAsync(userId);
            return NoContent();
        }
    }
}
