﻿using LevvaCoins.Application.UseCases.Transactions.Common;
using MediatR;

namespace LevvaCoins.Application.UseCases.Transactions.GetAllTransactions;

public class GetAllTransactionsInput : IRequest<IEnumerable<TransactionDetailsOutput>>
{
    public Guid UserId { get; set; }

    public GetAllTransactionsInput(Guid userId)
    {
        UserId = userId;
    }
}
