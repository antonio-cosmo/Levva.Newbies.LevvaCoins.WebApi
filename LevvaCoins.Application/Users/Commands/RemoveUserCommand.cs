using MediatR;

namespace LevvaCoins.Application.Users.Commands
{
    public class RemoveUserCommand : IRequest
    {
        public Guid Id { get; set; }

        public RemoveUserCommand(Guid id)
        {
            Id = id;
        }
    }
}
