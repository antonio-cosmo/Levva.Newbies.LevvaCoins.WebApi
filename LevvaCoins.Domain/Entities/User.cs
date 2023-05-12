using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using LevvaCoins.Domain.Common;

namespace LevvaCoins.Domain.Entities
{
    public sealed class User
    {
        public Guid? Id { get; private set; } 
        string _name = string.Empty;
        string _email = string.Empty;
        string _password = string.Empty;
        string _avatar = string.Empty;
        public IList<Transaction>? Transactions { get; set; }

        public User(string name, string email, string password, string avatar, Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
            Name = name;
            Email = email;
            Password = password;
            Avatar = avatar;
            Transactions = new List<Transaction>();
        }

        public string Name
        {
            get => _name;
            private set
            {
                DomainExceptionValidation.When(string.IsNullOrWhiteSpace(value), "O nome não pode estar vazio");
                _name = value;
            }
        }
        public string Email
        {
            get => _email;
            private set
            {
                DomainExceptionValidation.When(string.IsNullOrWhiteSpace(value), "O email não pode estar vazio");
                _email = value;
            }
        }
        public string Password
        {
            get => _password;
            private set
            {
                DomainExceptionValidation.When(string.IsNullOrWhiteSpace(value), "A senha não pode estar vazia");
                _password = value;
            }
        }
        public string Avatar
        {
            get => _avatar;
            private set => _avatar = value;
        }

        public void UpdateEntity(string name, string avatar, string email, string password)
        {
            Name = name;
            Avatar = avatar;
            Email = email;
            Password = password;
        }

        public void UpdateEntity(string name, string avatar, string email)
        {
            Name = name;
            Avatar = avatar;
            Email = email;
        }

        public void UpdateEntity(string name, string avatar)
        {
            Name = name;
            Avatar = avatar;
        }

    }
}
