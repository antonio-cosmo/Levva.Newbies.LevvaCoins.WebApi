using LevvaCoins.Domain.Entities;
using MediatR;

namespace LevvaCoins.Application.UseCases.Transactions.Queries
{
    public class GetAllTransactionsByUserQuery : IRequest<IEnumerable<Transaction>>
    {
        public Guid UserId { get; set; }

        public GetAllTransactionsByUserQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
