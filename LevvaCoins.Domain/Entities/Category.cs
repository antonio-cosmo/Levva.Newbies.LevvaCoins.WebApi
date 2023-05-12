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
        public Guid? Id { get; private set; }

        string _description = string.Empty;
        public string Description {
            get => _description;
            private set
            {
                DomainExceptionValidation.When(string.IsNullOrWhiteSpace(value), "Descrição não pode ser vazia");
                _description = value;
            } 
        }
        public IList<Transaction>? Transactions { get; set; }

        public Category(string description, Guid? id = null) {    
            
            Id = id ?? Guid.NewGuid();
            Description = description;
            Transactions = null;
        }

        public void UpdateEntity(string description)
        {
            Description = description;
        }
        
    }
}
