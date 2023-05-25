using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Interfaces.Repositories;
using MediatR;

namespace LevvaCoins.Application.Transactions.Commands
{
    public class DeleteTransactionCommand:IRequest
    {
        public Guid Id { get; set; }

        public DeleteTransactionCommand(Guid id)
        {
            Id = id;
        }
    }

    public class DeleteTransactionCommandHandler : IRequestHandler<DeleteTransactionCommand>
    {
        readonly ITransactionRepository _transactionRepository;

        public DeleteTransactionCommandHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
            var transactionAlreadExist = await _transactionRepository.GetByIdAsync(request.Id);
            if (transactionAlreadExist is null) throw new ModelNotFoundException("Essa transação não existe.");
            await _transactionRepository.RemoveAsync(transactionAlreadExist);
        }
    }
}
