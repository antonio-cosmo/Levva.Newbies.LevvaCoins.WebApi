using AutoMapper;
using LevvaCoins.Application.Users.Dtos;
using LevvaCoins.Application.Users.Interfaces;
using LevvaCoins.Application.Users.Services;
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
        readonly IUserServices _accountServices;
        readonly IMapper _mapper;
        readonly IConfiguration _config;
        public AuthController(IUserServices accountServices, IMapper mapper, IConfiguration config)
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
            var account = await _accountServices.GetByEmailAsync(loginDto.Email ?? throw new ArgumentNullException("Email vazio", nameof(loginDto.Email)))
                ?? throw new NotAuthorizedException("Usuário ou senha inválidos.");

            var currentPassword = new PasswordHash(loginDto.Password ?? throw new ArgumentNullException("Senha vazio", nameof(loginDto.Password)));

            if (!currentPassword.IsSame(account.Password))
                throw new NotAuthorizedException("Usuário ou senha inválidos.");

            var accounWithToken = _mapper.Map<LoginResponseDto>(account);

            accounWithToken.Token = TokenService.GenereteToken(account, _config);

            return Ok(accounWithToken);
        }
    }
}
