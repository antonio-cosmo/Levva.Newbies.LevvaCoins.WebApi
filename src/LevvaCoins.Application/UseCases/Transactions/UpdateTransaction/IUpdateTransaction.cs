using LevvaCoins.Application.Exceptions;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Repositories;
using LevvaCoins.Domain.ValueObjects;
using MediatR;

namespace LevvaCoins.Application.UseCases.Transactions.UpdateTransaction;

public interface IUpdateTransaction : IRequestHandler<UpdateTransactionInput>
{
}
