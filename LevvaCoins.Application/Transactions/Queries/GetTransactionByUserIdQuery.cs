using LevvaCoins.Domain.Common;
using LevvaCoins.Domain.Entities;
using MediatR;

namespace LevvaCoins.Application.Transactions.Queries
{
    public class GetTransactionByUserIdQuery : IRequest<PagedResult<Transaction>>
    {
        public Guid UserId { get; set; }
        public PaginationOptions PaginationOpt { get; set; }

        public GetTransactionByUserIdQuery(Guid userId, PaginationOptions paginationOpt)
        {
            UserId = userId;
            PaginationOpt = paginationOpt;
        }
    }
}
