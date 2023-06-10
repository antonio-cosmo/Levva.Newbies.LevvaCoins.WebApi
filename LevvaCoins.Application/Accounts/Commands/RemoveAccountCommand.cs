using MediatR;

namespace LevvaCoins.Application.Accounts.Commands
{
    public class RemoveAccountCommand : IRequest
    {
        public Guid Id { get; set; }

        public RemoveAccountCommand(Guid id)
        {
            Id = id;
        }
    }
}
