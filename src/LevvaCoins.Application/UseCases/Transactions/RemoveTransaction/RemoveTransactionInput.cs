using MediatR;

namespace LevvaCoins.Application.UseCases.Transactions.RemoveTransaction
{
    public class RemoveTransactionInput : IRequest
    {
        public Guid Id { get; set; }

        public RemoveTransactionInput(Guid id)
        {
            Id = id;
        }
    }
}
