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
    
        readonly IConfiguration _config;
        public AccountController(IAccountServices accountServices, IConfiguration config)
        {
            _accountServices = accountServices;
            _config = config;
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


        [HttpGet("{userId:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AccountDto>> GetByIdAsync([FromRoute] Guid userId)
        {
            var account = await _accountServices.GetAccountByIdAsync(userId);
            return Ok(account);
        }

   
        [HttpPut("{userId:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PutAsync([FromRoute] Guid userId, [FromBody] UpdateAccountDto body)
        {
            await _accountServices.UpdateAccountAsync(userId, body);
            return NoContent();
        }


  
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
