using LevvaCoins.Application.Exceptions;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.SeedWork;

namespace LevvaCoins.Application.UseCases.Transactions.RemoveTransaction;

public class RemoveTransactionHandler : IRemoveTransactionHandler
{
    private readonly IUnitOfWork _unitOfWork;
    public RemoveTransactionHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(RemoveTransaction request, CancellationToken cancellationToken)
    {
        var transaction = await FindTransaction(request.Id, cancellationToken);
        await _unitOfWork.TransactionRepository.RemoveAsync(transaction, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
    }
    private async Task<Transaction> FindTransaction(Guid id, CancellationToken cancellationToken)
    {
        return await _unitOfWork.TransactionRepository.GetAsync(id, cancellationToken)
            ?? throw new ModelNotFoundException("Essa transação não existe.");
    }
}
