using AutoMapper;
using LevvaCoins.Application.Transactions.Commands;
using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Interfaces.Repositories;
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

            transaction.Update(
                    request.Description,
                    request.Amount,
                    request.Type,
                    request.CategoryId
                );
            ValidateTransaction(transaction);

            await _transactionRepository.UpdateAsync(transaction);
        }
        private async Task<Transaction> GetTransactionById(Guid id)
        {
            return await _transactionRepository.GetByIdAsync(id) ?? throw new ModelNotFoundException("Essa transação não existe.");
        }
        private static void ValidateTransaction(Transaction transaction)
        {
            if (!transaction.IsValid())
            {
                throw new DomainValidationException("Entidade invalida");
            }
        }
    }
}
