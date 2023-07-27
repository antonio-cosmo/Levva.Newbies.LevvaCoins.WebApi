using AutoMapper;
using LevvaCoins.Application.UseCases.Transactions.Common;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.SeedWork;

namespace LevvaCoins.Application.UseCases.Transactions.CreateTransaction;

public class CreateTransaction : ICreateTransaction
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateTransaction( IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TransactionDetailsModelOutput> Handle(CreateTransactionInput request, CancellationToken cancellationToken)
    {
        var newTransaction = new Transaction(
                request.Description,
                request.Amount,
                request.Type,
                request.CategoryId,
                request.UserId
            );

        await _unitOfWork.TransactionRepository.InsertAsync(newTransaction, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        newTransaction.Category = await _unitOfWork.CategoryRepository.GetAsync(request.CategoryId, cancellationToken);

        return TransactionDetailsModelOutput.FromDomain(newTransaction);
    }
}
