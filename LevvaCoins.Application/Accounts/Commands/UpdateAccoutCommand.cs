using MediatR;

namespace LevvaCoins.Application.Accounts.Commands
{
    public class UpdateAccoutCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }

        public UpdateAccoutCommand(Guid id, string name, string avatar)
        {
            Id = id;
            Name = name;
            Avatar = avatar;
        }
    }
}
