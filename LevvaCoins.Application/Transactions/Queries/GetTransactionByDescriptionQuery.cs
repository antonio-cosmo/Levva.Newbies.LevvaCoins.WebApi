using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Interfaces.Repositories;
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

    public class GetTransactionByDescriptionQueryHandler : IRequestHandler<GetTransactionByDescriptionQuery, IEnumerable<Transaction>>
    {
        readonly ITransactionRepository _transactionRepository;

        public GetTransactionByDescriptionQueryHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<IEnumerable<Transaction>> Handle(GetTransactionByDescriptionQuery request, CancellationToken cancellationToken)
        {
            return await _transactionRepository.SearchByDescriptionAndIncludeCategoryAsync(request.UserId,request.Text);
          
        }
    }
}
