using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevvaCoins.Domain.Enums;

namespace LevvaCoins.Application.UseCases.Transactions.Dtos
{
    public class TransactionDto
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public ETransactionType Type { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
