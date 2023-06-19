using System.Xml.Linq;
using LevvaCoins.Domain.Validation;

namespace LevvaCoins.Domain.Entities
{
    public sealed class User : Entity
    {
        public string Name { get; private set; }
        public string Email { get;}
        public string Password { get;}
        public string? Avatar { get; private set; }
        public IList<Transaction>? Transactions { get; set; }

        public User(string name, string email, string password, string? avatar = null)
        {
            Name = name;
            Email = email;
            Password = password;
            Avatar = avatar;
            Transactions = new List<Transaction>();
        }
        public void Update(string name, string avatar)
        {
            Name = name;
            Avatar = avatar;
        }

        public override void Validate()
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(Name), "O nome não pode estar vazio");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(Email), "O email não pode estar vazio");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(Password), "A senha não pode estar vazia");
            DomainExceptionValidation.When(Avatar?.Length > 255, "A url da imagem não pode ser maior que 255 caracteres");
        }
    }
}
