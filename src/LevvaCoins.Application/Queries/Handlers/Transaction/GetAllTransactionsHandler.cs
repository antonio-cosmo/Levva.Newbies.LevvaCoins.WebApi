using LevvaCoins.Application.Queries.Interfaces.Transaction;
using LevvaCoins.Application.Queries.Requests.Transaction;
using LevvaCoins.Application.Responses;
using LevvaCoins.Application.Services.Interfaces;

namespace LevvaCoins.Application.Queries.Handlers.Transaction;

public class GetAllTransactionsHandler : IGetAllTransactionsHandler
{
    private readonly ITransactionService _transactionService;

    public GetAllTransactionsHandler(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    public async Task<IEnumerable<TransactionDetailsModelResponse>> Handle(GetAllTransactionsRequest request,
        CancellationToken cancellationToken)
    {
        return await _transactionService.GetAllAsync(request.UserId, cancellationToken);
    }
}