using LevvaCoins.Application.Exceptions;
using LevvaCoins.Application.UseCases.Transactions.Commands;
using LevvaCoins.Domain.Repositories;
using MediatR;

namespace LevvaCoins.Application.UseCases.Transactions.Handlers
{
    public class RemoveTransactionCommandHandler : IRequestHandler<RemoveTransactionCommand>
    {
        readonly ITransactionRepository _transactionRepository;

        public RemoveTransactionCommandHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task Handle(RemoveTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _transactionRepository.GetAsync(request.Id, cancellationToken)
                ?? throw new ModelNotFoundException("Essa transação não existe.");

            await _transactionRepository.RemoveAsync(transaction, cancellationToken);
        }
    }
}
