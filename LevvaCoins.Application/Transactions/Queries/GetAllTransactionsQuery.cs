using LevvaCoins.Domain.Entities;
using MediatR;

namespace LevvaCoins.Application.Transactions.Queries
{
    public class GetAllTransactionsQuery: IRequest<IEnumerable<Transaction>>
    {
        public Guid UserId { get; set; }

        public GetAllTransactionsQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
