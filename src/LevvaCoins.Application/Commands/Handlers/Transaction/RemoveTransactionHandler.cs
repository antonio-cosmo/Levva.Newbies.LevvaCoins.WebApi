using LevvaCoins.Application.Commands.Interfaces.Transaction;
using LevvaCoins.Application.Commands.Requests.Transaction;
using LevvaCoins.Application.Services.Interfaces;

namespace LevvaCoins.Application.Commands.Handlers.Transaction;

public class RemoveTransactionHandler : IRemoveTransactionHandler
{
    private readonly ITransactionService _transactionService;

    public RemoveTransactionHandler(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    public async Task Handle(RemoveTransactionRequest request, CancellationToken cancellationToken)
    {
        await _transactionService.RemoveAsync(request.Id, cancellationToken);
    }
}