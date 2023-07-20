using LevvaCoins.Application.Exceptions;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Repositories;
using LevvaCoins.Domain.SeedWork;
using LevvaCoins.Domain.ValueObjects;
using MediatR;

namespace LevvaCoins.Application.UseCases.Transactions.UpdateTransaction
{
    public class UpdateTransaction : IUpdateTransaction
    {
        readonly ITransactionRepository _transactionRepository;
        private IUnitOfWork _unitOfWork;
        public UpdateTransaction(ITransactionRepository transactionRepository, IUnitOfWork unitOfWork)
        {
            _transactionRepository = transactionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateTransactionInput request, CancellationToken cancellationToken)
        {
            var transaction = await FindTransaction(request.Id, cancellationToken);

            transaction.ChangeDescription(request.Description);
            transaction.ChangeType(request.Type);
            transaction.ChangeAmount(request.Amount);
            transaction.ChangeCategory(request.CategoryId);

            await _transactionRepository.UpdateAsync(transaction, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
        private async Task<Transaction> FindTransaction(Guid id, CancellationToken cancellationToken)
        {
            return await _transactionRepository.GetAsync(id, cancellationToken)
                ?? throw new ModelNotFoundException("Essa transação não existe.");
        }
    }
}
