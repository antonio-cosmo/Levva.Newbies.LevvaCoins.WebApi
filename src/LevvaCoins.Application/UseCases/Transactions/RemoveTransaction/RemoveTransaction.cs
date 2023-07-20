using LevvaCoins.Application.Exceptions;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Repositories;
using LevvaCoins.Domain.SeedWork;
using MediatR;

namespace LevvaCoins.Application.UseCases.Transactions.RemoveTransaction
{
    public class RemoveTransaction : IRemoveTransaction
    {
        readonly ITransactionRepository _transactionRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RemoveTransaction(ITransactionRepository transactionRepository, IUnitOfWork unitOfWork)
        {
            _transactionRepository = transactionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveTransactionInput request, CancellationToken cancellationToken)
        {
            var transaction = await FindTransaction(request.Id, cancellationToken);
            await _transactionRepository.RemoveAsync(transaction, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
        private async Task<Transaction> FindTransaction(Guid id, CancellationToken cancellationToken)
        {
            return await _transactionRepository.GetAsync(id, cancellationToken)
                ?? throw new ModelNotFoundException("Essa transação não existe.");
        }
    }
}
