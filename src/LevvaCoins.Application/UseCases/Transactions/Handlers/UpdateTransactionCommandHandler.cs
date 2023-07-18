using AutoMapper;
using LevvaCoins.Application.UseCases.Transactions.Commands;
using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Repositories;
using LevvaCoins.Domain.ValueObjects;
using MediatR;

namespace LevvaCoins.Application.UseCases.Transactions.Handlers
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
            var transaction = await GetTransactionById(request.Id, cancellationToken);
            var description = new Description(request.Description);

            transaction.ChangeDescription(description);
            transaction.ChangeType(request.Type);
            transaction.ChangeAmount(request.Amount);
            transaction.ChangeCategory(request.CategoryId);

            await _transactionRepository.UpdateAsync(transaction, cancellationToken);
        }
        private async Task<Transaction> GetTransactionById(Guid id, CancellationToken cancellationToken)
        {
            return await _transactionRepository.GetAsync(id, cancellationToken) ?? throw new ModelNotFoundException("Essa transação não existe.");
        }
    }
}
