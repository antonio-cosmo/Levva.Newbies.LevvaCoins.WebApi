using LevvaCoins.Application.Transactions.Queries;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Interfaces.Repositories;
using MediatR;

namespace LevvaCoins.Application.Transactions.Handlers
{
    public class GetAllTransactionsByUserQueryHandler : IRequestHandler<GetAllTransactionsByUserQuery, IEnumerable<Transaction>>
    {
        readonly ITransactionRepository _transactionRepository;
        public GetAllTransactionsByUserQueryHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public async Task<IEnumerable<Transaction>> Handle(GetAllTransactionsByUserQuery request, CancellationToken cancellationToken) =>
            await _transactionRepository.GetAllByUserAsync(request.UserId);
    }
}
