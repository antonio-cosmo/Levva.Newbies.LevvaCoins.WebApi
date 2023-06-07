using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevvaCoins.Domain.Enums;

namespace LevvaCoins.Application.Transactions.Dtos
{
    public class TransactionDto
    {
        public Guid? Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public double Amount { get; set; }
        public TransactionTypeEnum Type { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; }

        public TransactionDto(DateTime createdAt)
        {
            CreatedAt = createdAt;
        }

    }
}
