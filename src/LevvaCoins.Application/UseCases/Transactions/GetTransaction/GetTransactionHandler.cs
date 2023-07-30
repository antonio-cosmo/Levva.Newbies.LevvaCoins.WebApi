using LevvaCoins.Application.Exceptions;
using LevvaCoins.Application.UseCases.Transactions.Common;
using LevvaCoins.Domain.SeedWork;

namespace LevvaCoins.Application.UseCases.Transactions.GetTransaction;

public class GetTransactionHandler : IGetTransactionHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public GetTransactionHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TransactionModelResponse> Handle(GetTransaction request, CancellationToken cancellationToken)
    {
        var transaction =  await _unitOfWork.TransactionRepository.GetAsync(request.Id, cancellationToken)
            ?? throw new ModelNotFoundException("Essa transação não existe.");
        return TransactionModelResponse.FromDomain(transaction);
    }
}
