using LevvaCoins.Application.Commands.Interfaces.Transaction;
using LevvaCoins.Application.Commands.Requests.Transaction;
using LevvaCoins.Application.Responses;
using LevvaCoins.Application.Services.Interfaces;

namespace LevvaCoins.Application.Commands.Handlers.Transaction;

public class CreateTransactionHandler : ICreateTransactionHandler
{
    private readonly ITransactionService _transactionService;

    public CreateTransactionHandler(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    public async Task<TransactionDetailsModelResponse> Handle(CreateTransactionRequest request,
        CancellationToken cancellationToken)
    {
        return await _transactionService.InsertAsync(request, cancellationToken);
    }
}