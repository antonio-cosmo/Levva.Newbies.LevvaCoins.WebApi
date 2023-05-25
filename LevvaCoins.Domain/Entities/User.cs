using LevvaCoins.Domain.Validation;

namespace LevvaCoins.Domain.Entities
{
    public sealed class User:Entity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string? Avatar { get; private set; }
        public IList<Transaction>? Transactions { get; set; }

        public User(string name, string email, string password, string? avatar = null, Guid? id = null)
        {
            Validate(name,email,password, avatar);

            Id = id ?? Guid.NewGuid();
            Name = name;
            Email = email;
            Password = password;
            Avatar = avatar;
            Transactions = new List<Transaction>();
        }   
        public void Update(string name, string avatar)
        {
            Validate(name, avatar);
            Name = name;
            Avatar = avatar;

        }
        private void Validate(string name, string email, string password, string? avatar)
        {
            Validate(name, avatar);
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(email), "O email não pode estar vazio");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(password), "A senha não pode estar vazia");
        }
        private void Validate(string name, string? avatar)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name), "O nome não pode estar vazio");
            DomainExceptionValidation.When(avatar?.Length > 255, "A url da imagem não pode ser maior que 255 caracteres");
        }

    }
}
