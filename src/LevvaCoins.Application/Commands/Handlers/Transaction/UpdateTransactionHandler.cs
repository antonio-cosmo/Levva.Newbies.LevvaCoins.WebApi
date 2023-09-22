using LevvaCoins.Application.Commands.Interfaces.Transaction;
using LevvaCoins.Application.Commands.Requests.Transaction;
using LevvaCoins.Application.Services.Interfaces;

namespace LevvaCoins.Application.Commands.Handlers.Transaction;

public class UpdateTransactionHandler : IUpdateTransactionHandler
{
    private readonly ITransactionService _transactionService;

    public UpdateTransactionHandler(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    public async Task Handle(UpdateTransactionRequest request, CancellationToken cancellationToken)
    {
        await _transactionService.UpdateAsync(request, cancellationToken);
    }
}