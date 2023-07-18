using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using LevvaCoins.Application.Helpers;
using LevvaCoins.Application.UseCases.Users.Dtos;
using LevvaCoins.Application.UseCases.Users.Extensions;
using LevvaCoins.Application.UseCases.Users.Interfaces;
using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace LevvaCoins.Application.UseCases.Users.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        readonly IUserServices _userServices;
        readonly IMapper _mapper;

        public AuthenticateService(IUserServices accountServices, IMapper mapper)
        {
            _userServices = accountServices;
            _mapper = mapper;
        }
        public async Task<LoginResponseDto> GenerateToken(LoginDto login)
        {
            var user = await AuthenticateUser(login);
            var loginResponse = _mapper.Map<LoginResponseDto>(user);
            loginResponse.Token = CreateToken(user);
            return loginResponse;
        }
        private static string CreateToken(User user)
        {
            var userClaims = user.GetClaims();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("SECRET__KEY")
                                       ?? throw new NullReferenceException());
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(userClaims),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return $"Bearer {tokenHandler.WriteToken(token)}";
        }
        private async Task<User> AuthenticateUser(LoginDto login)
        {
            var email = login.Email ?? throw new NullReferenceException(nameof(login.Email));
            var password = login.Password ?? throw new NullReferenceException(nameof(login.Password));

            var user = await _userServices.GetByEmailAsync(email);

            if (user == null || !new PasswordHash(password).IsSame(user.Password))
            {
                throw new NotAuthorizedException("Usuário ou senha inválidos.");
            }

            return user;
        }
    }
}
