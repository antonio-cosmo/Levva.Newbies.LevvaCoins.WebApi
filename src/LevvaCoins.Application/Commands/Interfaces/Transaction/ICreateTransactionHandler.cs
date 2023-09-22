using LevvaCoins.Application.Commands.Requests.Transaction;
using LevvaCoins.Application.Responses;
using MediatR;

namespace LevvaCoins.Application.Commands.Interfaces.Transaction;

public interface ICreateTransactionHandler : IRequestHandler<
    CreateTransactionRequest, TransactionDetailsModelResponse>
{
}