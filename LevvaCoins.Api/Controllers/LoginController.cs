using AutoMapper;
using LevvaCoins.Application.Accounts.Dtos;
using LevvaCoins.Application.Accounts.Interfaces;
using LevvaCoins.Application.Accounts.Services;
using LevvaCoins.Application.Common.Dtos;
using LevvaCoins.Application.Utils;
using LevvaCoins.Domain.AppExceptions;
using Microsoft.AspNetCore.Mvc;

namespace LevvaCoins.Api.Controllers
{
    [Route("api/auth")]
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

            var accountAlreadExists = await _accountServices.GetAccountByEmailAsync(loginDto.Email);
            if (accountAlreadExists is null) throw new ModelNotFoundException("Usuário ou senha inválidos.");

            if (!HashFunction.Verify(loginDto.Password, accountAlreadExists.Password!)) throw new ModelNotFoundException("Usuário ou senha inválidos.");

            var accounWithToken = _mapper.Map<AccountWithTokenDto>(accountAlreadExists);
            accounWithToken.Token = TokenService.GenereteToken(accountAlreadExists, _config);

            return Ok(accounWithToken);
        }
    }
}
