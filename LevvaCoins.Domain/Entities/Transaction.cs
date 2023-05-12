using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevvaCoins.Domain.Common;
using LevvaCoins.Domain.Enums;

namespace LevvaCoins.Domain.Entities
{
    public sealed class Transaction
    {
        public Guid? Id { get; private set; }
        string _description = string.Empty;
        double _amount;
        TransactionTypeEnum _type;
        Guid _categoryId;
        Guid _userId;
        public User? User { get; set; }
        public Category? Category { get; set; }

        public Transaction(string description, double amount, TransactionTypeEnum type, Guid categoryId, Guid userId, Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
            Description = description;
            Amount = amount;
            Type = (TransactionTypeEnum) type;
            CategoryId = categoryId;
            UserId = userId;
        }

        public Transaction(string description, double amount, TransactionTypeEnum type, Guid categoryId, Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
            Description = description;
            Amount = amount;
            Type = (TransactionTypeEnum)type;
            CategoryId = categoryId;
        }


        public DateTime CreatedAt { get; }
        public string Description
        {
            get => _description;
            private set
            {
                DomainExceptionValidation.When(string.IsNullOrWhiteSpace(value), "Descrição não pode ser vazia");
                _description = value;
            }
        }
        public double Amount
        {
            get => _amount;
            private set
            {
                DomainExceptionValidation.When(value < 0, "Valor não pode ser negativo");
                _amount = value;
            }
        }
        public TransactionTypeEnum Type
        {
            get => _type;
            private set
            {
                var teste = (int) value;
                DomainExceptionValidation.When(teste !=0 && teste !=1, "Informe um tipo valido de transação");
                _type = value;
            }
        }
        public Guid CategoryId
        {
            get => _categoryId;
            private set
            {
                DomainExceptionValidation.When(value == Guid.Empty || string.IsNullOrWhiteSpace(value.ToString()),
                                                "Informe uma categoria valida");

                _categoryId = value;
            }
        }
        public Guid UserId
        {
            get => _userId;
            private set
            {
                DomainExceptionValidation.When(value == Guid.Empty || string.IsNullOrWhiteSpace(value.ToString()),
                                                "Informe uma usuario valido");

                _userId = value;
            }
        }


        public void UpdateEntity(string description, double amount, TransactionTypeEnum type, Guid categoryId)
        {
            Description = description;
            Amount = amount;
            Type = type;
            CategoryId = categoryId;
        }
    }
}
