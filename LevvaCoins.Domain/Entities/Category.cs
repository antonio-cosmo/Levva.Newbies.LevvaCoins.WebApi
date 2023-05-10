using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevvaCoins.Domain.Common;

namespace LevvaCoins.Domain.Entities
{
    public sealed class Category
    {
        public Guid Id { get; private set; }
        public string? Description { get; set; }
        public IList<Transaction> Transactions { get; set; }

        public Category(string description) {
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Descrição não pode ser vazia");

            Description = description.ToLower();
            Transactions = new List<Transaction>();
        }
    }
}
