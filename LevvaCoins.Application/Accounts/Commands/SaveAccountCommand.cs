using LevvaCoins.Application.Helpers;
using LevvaCoins.Domain.Entities;
using MediatR;

namespace LevvaCoins.Application.Accounts.Commands
{
    public class SaveAccountCommand : IRequest<User>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }

        public SaveAccountCommand(string name, string email, string password, string avatar)
        {
            Name = name;
            Email = email;
            Password = PasswordHash.Generate(password); ;
            Avatar = avatar;
        }
    }
}
