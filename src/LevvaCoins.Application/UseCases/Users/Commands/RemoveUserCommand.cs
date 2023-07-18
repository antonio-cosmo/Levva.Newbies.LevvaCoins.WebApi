using MediatR;

namespace LevvaCoins.Application.UseCases.Users.Commands
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
