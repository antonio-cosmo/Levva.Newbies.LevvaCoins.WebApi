using LevvaCoins.Application.Services.Dtos.User;
using LevvaCoins.Application.UseCases.Users.Helpers;
using MediatR;

namespace LevvaCoins.Application.UseCases.Users.CreateUser
{
    public class CreateUser : IRequest<UserModelResponse>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }

        public CreateUser(string name, string email, string password, string avatar)
        {
            Name = name;
            Email = email;
            Password = new PasswordHash(password).HashedValue;
            Avatar = avatar;
        }
    }
}
