using AutoMapper;
using LevvaCoins.Application.Transactions.Commands;
using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Repositories;
using LevvaCoins.Domain.ValueObjects;
using MediatR;

namespace LevvaCoins.Application.Transactions.Handlers
{
    public class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand>
    {
        readonly ITransactionRepository _transactionRepository;

        public UpdateTransactionCommandHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = await GetTransactionById(request.Id);
            var description = new Description(request.Description);

            transaction.ChangeDescription(description);
            transaction.ChangeType(request.Type);
            transaction.ChangeAmount(request.Amount);
            transaction.ChangeCategory(request.CategoryId);

            ValidateTransaction(transaction);

            await _transactionRepository.UpdateAsync(transaction);
        }
        private async Task<Transaction> GetTransactionById(Guid id)
        {
            return await _transactionRepository.GetAsync(id) ?? throw new ModelNotFoundException("Essa transação não existe.");
        }
        private static void ValidateTransaction(Transaction transaction)
        {
            if (!transaction.IsValid)
            {
                throw new DomainValidationException("Entidade invalida");
            }
        }
    }
}
