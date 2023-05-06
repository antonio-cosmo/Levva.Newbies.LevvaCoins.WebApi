using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevvaCoins.Domain.Entities
{
    public sealed class Category
    {
        public Guid Id { get; private set; }
        public string? Description { get; set; }
        public IList<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
