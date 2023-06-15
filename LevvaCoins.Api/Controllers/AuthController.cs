using AutoMapper;
using LevvaCoins.Application.Accounts.Dtos;
using LevvaCoins.Application.Accounts.Interfaces;
using LevvaCoins.Application.Accounts.Services;
using LevvaCoins.Application.Common.Dtos;
using LevvaCoins.Application.Helpers;
using LevvaCoins.Domain.AppExceptions;
using Microsoft.AspNetCore.Mvc;

namespace LevvaCoins.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IAccountServices _accountServices;
        readonly IMapper _mapper;
        readonly IConfiguration _config;
        public AuthController(IAccountServices accountServices, IMapper mapper, IConfiguration config)
        {
            _accountServices = accountServices;
            _mapper = mapper;
            _config = config;
        }
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<LoginResponseDto>> PostAuthAsync([FromBody] LoginDto loginDto)
        {

            var account = await _accountServices.GetByEmailAsync(loginDto.Email);
            if (account is null) throw new NotAuthorizedException("Usuário ou senha inválidos.");

            if (!PasswordHash.Verify(loginDto.Password, account.Password)) 
                throw new NotAuthorizedException("Usuário ou senha inválidos.");

            var accounWithToken = _mapper.Map<LoginResponseDto>(account);
            accounWithToken.Token = TokenService.GenereteToken(account, _config);

            return Ok(accounWithToken);
        }
    }
}
