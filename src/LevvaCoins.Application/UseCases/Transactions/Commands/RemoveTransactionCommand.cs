using MediatR;

namespace LevvaCoins.Application.UseCases.Transactions.Commands
{
    public class RemoveTransactionCommand : IRequest
    {
        public Guid Id { get; set; }

        public RemoveTransactionCommand(Guid id)
        {
            Id = id;
        }
    }
}
