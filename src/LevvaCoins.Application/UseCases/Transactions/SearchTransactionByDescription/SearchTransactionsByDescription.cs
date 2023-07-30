using LevvaCoins.Application.UseCases.Transactions.Common;
using MediatR;

namespace LevvaCoins.Application.UseCases.Transactions.SearchTransactionByDescription
{
    public class SearchTransactionsByDescription : IRequest<IEnumerable<TransactionDetailsModelResponse>>
    {
        public Guid UserId { get; set; }
        public string Text { get; set; }
        public SearchTransactionsByDescription(Guid userId, string text)
        {
            UserId = userId;
            Text = text;
        }
    }
}
