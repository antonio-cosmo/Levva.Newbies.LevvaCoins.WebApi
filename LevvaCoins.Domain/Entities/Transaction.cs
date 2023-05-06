using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevvaCoins.Domain.Entities
{
    public sealed class Transaction
    {
        public Guid Id { get; private set; }
        public string? Description { get; set; }
        public double Amount { get; set; }
        public string? Type { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; private set; }
        public User? User { get; set; }
        public Category? Category { get; set; }
    }
}
