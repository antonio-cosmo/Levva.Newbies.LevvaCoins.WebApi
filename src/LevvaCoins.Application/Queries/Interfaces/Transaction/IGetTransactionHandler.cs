using LevvaCoins.Application.Queries.Requests.Transaction;
using LevvaCoins.Application.Responses;
using MediatR;

namespace LevvaCoins.Application.Queries.Interfaces.Transaction;

public interface IGetTransactionHandler : IRequestHandler<GetTransactionRequest, TransactionModelResponse>
{
}