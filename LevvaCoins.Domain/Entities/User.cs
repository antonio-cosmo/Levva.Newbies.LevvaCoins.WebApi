using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevvaCoins.Domain.Entities
{
    public sealed class User
    {
        public Guid Id { get; private set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Avatar { get; set; }
        public IList<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
