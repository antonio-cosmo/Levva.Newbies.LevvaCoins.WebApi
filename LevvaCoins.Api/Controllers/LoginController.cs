using AutoMapper;
using LevvaCoins.Application.Accounts.Dtos;
using LevvaCoins.Application.Accounts.Interfaces;
using LevvaCoins.Application.Accounts.Services;
using LevvaCoins.Application.Common.Dtos;
using LevvaCoins.Application.Utility;
using LevvaCoins.Domain.AppExceptions;
using Microsoft.AspNetCore.Mvc;

namespace LevvaCoins.Api.Controllers
{
    [Route("auth")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        readonly IAccountServices _accountServices;
        readonly IMapper _mapper;
        readonly IConfiguration _config;
        public LoginController(IAccountServices accountServices, IMapper mapper, IConfiguration config)
        {
            _accountServices = accountServices;
            _mapper = mapper;
            _config = config;
        }
        [HttpPost()]
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
    }
}
