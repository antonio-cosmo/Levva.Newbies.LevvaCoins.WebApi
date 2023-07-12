using MediatR;

namespace LevvaCoins.Application.Transactions.Commands
{
    public class RemoveTransactionCommand:IRequest
    {
        public Guid Id { get; set; }

        public RemoveTransactionCommand(Guid id)
        {
            Id = id;
        }
    }
}
