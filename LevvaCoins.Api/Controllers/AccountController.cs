using AutoMapper;
using LevvaCoins.Application.Accounts.Dtos;
using LevvaCoins.Application.Accounts.Interfaces;
using LevvaCoins.Application.Accounts.Services;
using LevvaCoins.Application.Common.Dtos;
using LevvaCoins.Application.Utility;
using LevvaCoins.Domain.AppExceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LevvaCoins.Api.Controllers
{
    [Route("user")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        readonly IAccountServices _accountServices;
        readonly IMapper _mapper;
        readonly IConfiguration _config;
        public AccountController(IAccountServices accountServices,IMapper mapper ,IConfiguration config)
        {
            _accountServices = accountServices;
            _mapper = mapper;
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

        [HttpPost("/auth")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<AccountWithTokenDto>> PostAuthAsync([FromBody] LoginDto loginDto)
        {
            try
            {
                var account = await _accountServices.GetAccountByEmailAsync(loginDto.Email);

                if (!HashFunction.Verify(loginDto.Password, account.Password!)) throw new Exception();

                var accounWithToken = _mapper.Map<AccountWithTokenDto>(account);
                accounWithToken.Token = TokenService.GenereteToken(account, _config);

                return Ok(accounWithToken);
            }
            catch
            {
                throw new ModelNotFoundException("Usuário ou senha inválidos.");
            }
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
