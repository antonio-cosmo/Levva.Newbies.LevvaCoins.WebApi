﻿using LevvaCoins.Application.Commands.Requests.Transaction;
using MediatR;

namespace LevvaCoins.Application.Commands.Interfaces.Transaction;

public interface IRemoveTransactionHandler : IRequestHandler<RemoveTransactionRequest>
{
}