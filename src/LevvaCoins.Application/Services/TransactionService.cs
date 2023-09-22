using LevvaCoins.Application.Commands.Requests.Transaction;
using LevvaCoins.Application.Common;
using LevvaCoins.Application.Queries.Requests.Transaction;
using LevvaCoins.Application.Responses;
using LevvaCoins.Application.Services.Interfaces;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace LevvaCoins.Application.Services;

public class TransactionService : ITransactionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly NotificationContext _notificationContext;

    public TransactionService(IUnitOfWork unitOfWork, NotificationContext notificationContext)
    {
        _unitOfWork = unitOfWork;
        _notificationContext = notificationContext;
    }

    public async Task RemoveAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var transaction = await FindTransaction(id, cancellationToken);
        if (transaction is null)
        {
            _notificationContext.AddNotification("Exception", "Essa transação não existe.");
            return;
        }

        await _unitOfWork.TransactionRepository.RemoveAsync(transaction, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
    }

    public async Task<TransactionDetailsModelResponse> InsertAsync(CreateTransactionRequest request,
        CancellationToken cancellationToken = default)
    {
        var newTransaction = new Transaction(
            request.Description,
            request.Amount,
            request.Type,
            request.CategoryId,
            request.UserId
        );

        if (!newTransaction.IsValid)
        {
            _notificationContext.AddNotifications(newTransaction.Notifications);
            return null;
        }

        await _unitOfWork.TransactionRepository.InsertAsync(newTransaction, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        newTransaction.Category =
            await _unitOfWork.CategoryRepository.GetByIdAsync(request.CategoryId, cancellationToken);

        return TransactionDetailsModelResponse.FromDomain(newTransaction);
    }

    public async Task<IEnumerable<TransactionDetailsModelResponse>> GetAllAsync(Guid userId,
        CancellationToken cancellationToken = default)
    {
        var transactions = await _unitOfWork.TransactionRepository
            .GetAllIncludeAsync(x => x.Category!)
            .Where(x => x.UserId.Equals(userId))
            .ToListAsync(cancellationToken);


        return TransactionDetailsModelResponse.FromDomain(transactions);
    }

    public async Task UpdateAsync(UpdateTransactionRequest request, CancellationToken cancellationToken = default)
    {
        var transaction = await FindTransaction(request.Id, cancellationToken);
        if (transaction is null)
        {
            _notificationContext.AddNotification("Exception", "Essa transação não existe.");
            return;
        }

        transaction.ChangeDescription(request.Description);
        transaction.ChangeType(request.Type);
        transaction.ChangeAmount(request.Amount);
        transaction.ChangeCategory(request.CategoryId);

        if (!transaction.IsValid)
        {
            _notificationContext.AddNotifications(transaction.Notifications);
            return;
        }

        await _unitOfWork.TransactionRepository.UpdateAsync(transaction, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
    }

    public async Task<TransactionModelResponse> GetByIdAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        var transaction = await _unitOfWork.TransactionRepository.GetByIdAsync(id, cancellationToken);

        if (transaction is not null) return TransactionModelResponse.FromDomain(transaction);
        
        _notificationContext.AddNotification("Exception", "Essa transação não existe.");
        return null;
    }

    public async Task<IEnumerable<TransactionDetailsModelResponse>> SearchByDescriptionAsync(
        GetTransactionsByDescriptionRequest request, CancellationToken cancellationToken = default)
    {
        var transactions = await _unitOfWork.TransactionRepository
            .GetAllIncludeAsync(x => x.Category!)
            .Where(x => x.UserId == request.UserId &&
                        (EF.Functions.Like(x.Description, $"%{request.Text}%") ||
                         EF.Functions.Like(x.Category!.Description, $"%{request.Text}%"))
            )
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync(cancellationToken);

        return TransactionDetailsModelResponse.FromDomain(transactions);
    }

    private async Task<Transaction?> FindTransaction(Guid id, CancellationToken cancellationToken)
    {
        return await _unitOfWork.TransactionRepository.GetByIdAsync(id, cancellationToken);
    }
}