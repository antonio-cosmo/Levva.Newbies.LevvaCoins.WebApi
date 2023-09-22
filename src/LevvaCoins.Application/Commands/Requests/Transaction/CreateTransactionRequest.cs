using LevvaCoins.Application.Responses;
using LevvaCoins.Domain.Enums;
using MediatR;

namespace LevvaCoins.Application.Commands.Requests.Transaction;

public class CreateTransactionRequest : IRequest<TransactionDetailsModelResponse>
{
    public CreateTransactionRequest(string description, decimal amount, TransactionType type, Guid categoryId,
        Guid userId)
    {
        Description = description;
        Amount = amount;
        Type = type;
        CategoryId = categoryId;
        UserId = userId;
    }

    public string Description { get; set; }
    public decimal Amount { get; set; }
    public TransactionType Type { get; set; }
    public Guid CategoryId { get; set; }
    public Guid UserId { get; set; }
}