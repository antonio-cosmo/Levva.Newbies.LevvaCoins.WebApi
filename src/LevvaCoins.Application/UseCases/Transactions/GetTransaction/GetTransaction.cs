using LevvaCoins.Application.Exceptions;
using LevvaCoins.Application.UseCases.Transactions.Common;
using LevvaCoins.Domain.SeedWork;

namespace LevvaCoins.Application.UseCases.Transactions.GetTransaction;

public class GetTransaction : IGetTransaction
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTransaction(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TransactionModelOutput> Handle(GetTransactionInput request, CancellationToken cancellationToken)
    {
        var transaction =  await _unitOfWork.TransactionRepository.GetAsync(request.Id, cancellationToken)
            ?? throw new ModelNotFoundException("Essa transação não existe.");
        return TransactionModelOutput.FromDomain(transaction);
    }
}
