using LevvaCoins.Application.Commands.Requests.Transaction;
using LevvaCoins.Application.Queries.Requests.Transaction;
using LevvaCoins.Application.Responses;

namespace LevvaCoins.Application.Services.Interfaces;

public interface ITransactionService
{
    Task<TransactionDetailsModelResponse> InsertAsync(CreateTransactionRequest createTransactionRequest,
        CancellationToken cancellationToken);

    Task<IEnumerable<TransactionDetailsModelResponse>> GetAllAsync(Guid userId, CancellationToken cancellationToken);
    Task<TransactionModelResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task UpdateAsync(UpdateTransactionRequest updateTransactionRequest, CancellationToken cancellationToken);
    Task RemoveAsync(Guid id, CancellationToken cancellationToken);

    Task<IEnumerable<TransactionDetailsModelResponse>> SearchByDescriptionAsync(
        GetTransactionsByDescriptionRequest getTransactionsByDescriptionRequest, CancellationToken cancellationToken);
}