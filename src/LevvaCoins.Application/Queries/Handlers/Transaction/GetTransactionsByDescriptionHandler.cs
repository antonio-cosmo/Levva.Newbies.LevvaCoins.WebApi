using LevvaCoins.Application.Queries.Interfaces.Transaction;
using LevvaCoins.Application.Queries.Requests.Transaction;
using LevvaCoins.Application.Responses;
using LevvaCoins.Application.Services.Interfaces;

namespace LevvaCoins.Application.Queries.Handlers.Transaction;

public class GetTransactionsByDescriptionHandler : IGetTransactionsByDescriptionHandler
{
    private readonly ITransactionService _transactionService;

    public GetTransactionsByDescriptionHandler(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    public async Task<IEnumerable<TransactionDetailsModelResponse>> Handle(GetTransactionsByDescriptionRequest request,
        CancellationToken cancellationToken)
    {
        return await _transactionService.SearchByDescriptionAsync(request, cancellationToken);
    }
}