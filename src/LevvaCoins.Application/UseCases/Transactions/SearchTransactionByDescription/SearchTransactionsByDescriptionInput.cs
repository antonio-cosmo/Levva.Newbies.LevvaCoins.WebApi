using LevvaCoins.Application.UseCases.Transactions.Common;
using MediatR;

namespace LevvaCoins.Application.UseCases.Transactions.SearchTransactionByDescription
{
    public class SearchTransactionsByDescriptionInput : IRequest<IEnumerable<TransactionDetailsOutput>>
    {
        public Guid UserId { get; set; }
        public string Text { get; set; }
        public SearchTransactionsByDescriptionInput(Guid userId, string text)
        {
            UserId = userId;
            Text = text;
        }
    }
}
