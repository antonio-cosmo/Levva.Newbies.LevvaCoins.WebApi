using MediatR;

namespace LevvaCoins.Application.UseCases.Users.Commands
{
    public class UpdateUserCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }

        public UpdateUserCommand(Guid id, string name, string avatar)
        {
            Id = id;
            Name = name;
            Avatar = avatar;
        }
    }
}
