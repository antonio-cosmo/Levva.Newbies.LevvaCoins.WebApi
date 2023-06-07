using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Interfaces.Repositories;
using MediatR;

namespace LevvaCoins.Application.Transactions.Queries
{
    public class GetAllTransactionsQuery: IRequest<IEnumerable<Transaction>>
    {
        public Guid UserId { get; set; }

        public GetAllTransactionsQuery(Guid userId)
        {
            UserId = userId;
        }
    }

    public class GetAllTransactionsHandler : IRequestHandler<GetAllTransactionsQuery, IEnumerable<Transaction>>
    {
        readonly ITransactionRepository _transactionRepository;
        public GetAllTransactionsHandler(ITransactionRepository transactionRepository) 
        { 
            _transactionRepository = transactionRepository;
        }
        public async Task<IEnumerable<Transaction>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
        {
            return await _transactionRepository.GetAllTransactionIncludingCategory(request.UserId);
        }
    }
}
