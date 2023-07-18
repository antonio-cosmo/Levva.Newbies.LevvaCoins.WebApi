using LevvaCoins.Domain.Entities;
using MediatR;

namespace LevvaCoins.Application.UseCases.Transactions.Queries
{
    public class GetTransactionByIdQuery : IRequest<Transaction?>
    {
        public Guid Id { get; set; }

        public GetTransactionByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
