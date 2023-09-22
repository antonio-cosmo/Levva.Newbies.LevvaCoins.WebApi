using LevvaCoins.Application.Queries.Interfaces.Transaction;
using LevvaCoins.Application.Queries.Requests.Transaction;
using LevvaCoins.Application.Responses;
using LevvaCoins.Application.Services.Interfaces;

namespace LevvaCoins.Application.Queries.Handlers.Transaction;

public class GetTransactionHandler : IGetTransactionHandler
{
    private readonly ITransactionService _transactionService;

    public GetTransactionHandler(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    public async Task<TransactionModelResponse> Handle(GetTransactionRequest request,
        CancellationToken cancellationToken)
    {
        return await _transactionService.GetByIdAsync(request.Id, cancellationToken);
    }
}