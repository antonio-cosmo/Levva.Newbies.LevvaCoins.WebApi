﻿using LevvaCoins.Application.UseCases.Transactions.Common;
using MediatR;

namespace LevvaCoins.Application.UseCases.Transactions.CreateTransaction;

public interface ICreateTransactionHandler : IRequestHandler<CreateTransaction, TransactionDetailsModelResponse>
{
}
