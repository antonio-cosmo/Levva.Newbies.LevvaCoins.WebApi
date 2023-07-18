using LevvaCoins.Application.UseCases.Transactions.Queries;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Repositories;
using MediatR;

namespace LevvaCoins.Application.UseCases.Transactions.Handlers
{
    public class GetTransactionByIdQueryHandler : IRequestHandler<GetTransactionByIdQuery, Transaction?>
    {
        readonly ITransactionRepository _transactionRepository;

        public GetTransactionByIdQueryHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<Transaction?> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken) =>
            await _transactionRepository.GetAsync(request.Id, cancellationToken);

    }
}
