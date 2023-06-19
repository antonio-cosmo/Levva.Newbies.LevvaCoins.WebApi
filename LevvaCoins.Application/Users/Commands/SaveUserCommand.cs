using LevvaCoins.Application.Helpers;
using LevvaCoins.Domain.Entities;
using MediatR;

namespace LevvaCoins.Application.Users.Commands
{
    public class SaveUserCommand : IRequest<User>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }

        public SaveUserCommand(string name, string email, string password, string avatar)
        {
            Name = name;
            Email = email;
            Password = new PasswordHash(password).Value;
            Avatar = avatar;
        }
    }
}
