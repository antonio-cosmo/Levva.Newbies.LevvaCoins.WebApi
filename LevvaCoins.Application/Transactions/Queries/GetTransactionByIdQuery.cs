using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LevvaCoins.Application.Transactions.Dtos;
using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Interfaces.Repositories;
using MediatR;

namespace LevvaCoins.Application.Transactions.Queries
{
    public class GetTransactionByIdQuery : IRequest<Transaction?>
    {
        public Guid Id { get; set; }

        public GetTransactionByIdQuery(Guid id)
        {
            Id = id;
        }
    }

    public class GetTransactionByIdQueryHandler : IRequestHandler<GetTransactionByIdQuery, Transaction?>
    {
        readonly ITransactionRepository _transactionRepository;

        public GetTransactionByIdQueryHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<Transaction?> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
        {
            return await _transactionRepository.GetByIdAsync(request.Id);
          
        }
    }
}
