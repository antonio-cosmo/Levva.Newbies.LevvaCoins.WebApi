using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Interfaces.Repositories;
using MediatR;

namespace LevvaCoins.Application.Transactions.Commands
{
    public class RemoveTransactionCommand:IRequest
    {
        public Guid Id { get; set; }

        public RemoveTransactionCommand(Guid id)
        {
            Id = id;
        }
    }

    public class DeleteTransactionCommandHandler : IRequestHandler<RemoveTransactionCommand>
    {
        readonly ITransactionRepository _transactionRepository;

        public DeleteTransactionCommandHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task Handle(RemoveTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _transactionRepository.GetByIdAsync(request.Id);
            if (transaction is null) throw new ModelNotFoundException("Essa transação não existe.");
            await _transactionRepository.RemoveAsync(transaction);
        }
    }
}
