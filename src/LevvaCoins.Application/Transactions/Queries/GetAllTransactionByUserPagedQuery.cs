using LevvaCoins.Domain.Common;
using LevvaCoins.Domain.Entities;
using MediatR;

namespace LevvaCoins.Application.Transactions.Queries
{
    public class GetAllTransactionByUserPagedQuery : IRequest<PagedResult<Transaction>>
    {
        public Guid UserId { get; set; }
        public PaginationOptions PaginationOpt { get; set; }

        public GetAllTransactionByUserPagedQuery(Guid userId, PaginationOptions paginationOpt)
        {
            UserId = userId;
            PaginationOpt = paginationOpt;
        }
    }
}
