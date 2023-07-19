using LevvaCoins.Application.UseCases.Users.Common;
using LevvaCoins.Application.UseCases.Users.Helpers;
using MediatR;

namespace LevvaCoins.Application.UseCases.Users.CreateUser
{
    public class CreateUserInput : IRequest<UserOutput>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }

        public CreateUserInput(string name, string email, string password, string avatar)
        {
            Name = name;
            Email = email;
            Password = new PasswordHash(password).HashedValue;
            Avatar = avatar;
        }
    }
}
