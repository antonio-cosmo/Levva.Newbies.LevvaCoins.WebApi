using LevvaCoins.Application.Transactions.Commands;
using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Interfaces.Repositories;
using MediatR;

namespace LevvaCoins.Application.Transactions.Handlers
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
            try
            {
                var transaction = await _transactionRepository.GetByIdAsync(request.Id)
                    ?? throw new ModelNotFoundException("Essa transação não existe.");

                await _transactionRepository.RemoveAsync(transaction);
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
