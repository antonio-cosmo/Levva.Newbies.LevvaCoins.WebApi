using LevvaCoins.Application.UseCases.Transactions.Queries;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Repositories;
using MediatR;

namespace LevvaCoins.Application.UseCases.Transactions.Handlers
{
    public class GetAllTransactionsByUserQueryHandler : IRequestHandler<GetAllTransactionsByUserQuery, IEnumerable<Transaction>>
    {
        readonly ITransactionRepository _transactionRepository;
        public GetAllTransactionsByUserQueryHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public async Task<IEnumerable<Transaction>> Handle(GetAllTransactionsByUserQuery request, CancellationToken cancellationToken) =>
            await _transactionRepository.GetAllByUserAsync(request.UserId, cancellationToken);
    }
}
