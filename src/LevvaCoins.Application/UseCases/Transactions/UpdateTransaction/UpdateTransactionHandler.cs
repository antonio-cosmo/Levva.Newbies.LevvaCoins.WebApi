using LevvaCoins.Application.Exceptions;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.SeedWork;

namespace LevvaCoins.Application.UseCases.Transactions.UpdateTransaction;

public class UpdateTransactionHandler : IUpdateTransactionHandler
{
    private readonly IUnitOfWork _unitOfWork;
    public UpdateTransactionHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateTransaction request, CancellationToken cancellationToken)
    {
        var transaction = await FindTransaction(request.Id, cancellationToken);

        transaction.ChangeDescription(request.Description);
        transaction.ChangeType(request.Type);
        transaction.ChangeAmount(request.Amount);
        transaction.ChangeCategory(request.CategoryId);

        await _unitOfWork.TransactionRepository.UpdateAsync(transaction, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
    }
    private async Task<Transaction> FindTransaction(Guid id, CancellationToken cancellationToken)
    {
        return await _unitOfWork.TransactionRepository.GetAsync(id, cancellationToken)
            ?? throw new ModelNotFoundException("Essa transação não existe.");
    }
}
