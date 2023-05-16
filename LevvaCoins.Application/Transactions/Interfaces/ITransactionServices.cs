using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevvaCoins.Application.Transactions.Dtos;
using LevvaCoins.Domain.Common.Dtos;
using LevvaCoins.Domain.Common;
using LevvaCoins.Domain.Entities;

namespace LevvaCoins.Application.Transactions.Interfaces
{
    public interface ITransactionServices
    {
        Task CreateTransactionAsync(CreateTransactionDto transaction, Guid userId);
        Task<TransactionDto> GetByIdTransaction(Guid transactionId);
        Task UpdateTransaction(Guid id, UpdateTransactionDto transaction);
        Task DeleteByIdTransaction(Guid transactionId);
        Task<PagedResultDto<TransactionDto>> SearchTransactionByUser(Guid userId, PaginationOptions paginationOptions);
        Task<IEnumerable<TransactionDto>> SearchTransactionByDescription(string search);
    }
}
