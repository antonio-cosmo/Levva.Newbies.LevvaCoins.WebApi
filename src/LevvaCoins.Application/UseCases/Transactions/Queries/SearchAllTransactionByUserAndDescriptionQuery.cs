using LevvaCoins.Domain.Entities;
using MediatR;

namespace LevvaCoins.Application.UseCases.Transactions.Queries
{
    public class SearchAllTransactionByUserAndDescriptionQuery : IRequest<IEnumerable<Transaction>>
    {
        public Guid UserId { get; set; }
        public string Text { get; set; }
        public SearchAllTransactionByUserAndDescriptionQuery(Guid userId, string text)
        {
            UserId = userId;
            Text = text;
        }
    }
}
