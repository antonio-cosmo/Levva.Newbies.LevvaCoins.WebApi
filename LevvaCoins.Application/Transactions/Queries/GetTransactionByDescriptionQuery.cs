using LevvaCoins.Domain.Entities;
using MediatR;

namespace LevvaCoins.Application.Transactions.Queries
{
    public class GetTransactionByDescriptionQuery : IRequest<IEnumerable<Transaction>>
    {
        public Guid UserId { get; set; }

        public string Text { get; set; } 
        public GetTransactionByDescriptionQuery(Guid userId, string text)
        {
            UserId = userId;
            Text = text;
        }
    }
}
