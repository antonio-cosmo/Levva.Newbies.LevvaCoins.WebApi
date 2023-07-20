using LevvaCoins.Application.Exceptions;
using LevvaCoins.Application.UseCases.Transactions.Common;
using LevvaCoins.Domain.Repositories;

namespace LevvaCoins.Application.UseCases.Transactions.GetTransaction;

public class GetTransaction : IGetTransaction
{
    readonly ITransactionRepository _transactionRepository;

    public GetTransaction(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task<TransactionOutput> Handle(GetTransactionInput request, CancellationToken cancellationToken)
    {
        var transaction =  await _transactionRepository.GetAsync(request.Id, cancellationToken)
            ?? throw new ModelNotFoundException("Essa transação não existe.");
        return TransactionOutput.FromModel(transaction);
    }
}
