﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LevvaCoins.Application.Transactions.Dtos;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Interfaces.Repositories;
using MediatR;

namespace LevvaCoins.Application.Transactions.Queries
{
    public class GetTransactionByDescriptionQuery : IRequest<IEnumerable<Transaction>>
    {
        public string Text { get; set; } = string.Empty;

        public GetTransactionByDescriptionQuery(string text)
        {
            Text = text;
        }
    }

    public class GetTransactionByDescriptionQueryHandler : IRequestHandler<GetTransactionByDescriptionQuery, IEnumerable<Transaction>>
    {
        readonly ITransactionRepository _transactionRepository;

        public GetTransactionByDescriptionQueryHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<IEnumerable<Transaction>> Handle(GetTransactionByDescriptionQuery request, CancellationToken cancellationToken)
        {
            return await _transactionRepository.SearchTransactionByDescription(request.Text);
          
        }
    }
}