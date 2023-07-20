using LevvaCoins.Domain.SeedWork;
using LevvaCoins.Domain.Validation;

namespace LevvaCoins.Domain.Entities
{
    public sealed class User : Entity
    {
        private const int MAX_AVATAR_LENGTH = 255;
        public string Name { get; private set; }
        public string Email { get; }
        public string Password { get; }
        public string? Avatar { get; private set; }
        public IList<Transaction>? Transactions { get; set; }
        public User(string name, string email, string password, string? avatar = null)
        {
            Name = name;
            Email = email;
            Password = password;
            Avatar = avatar;
            Transactions = new List<Transaction>();
            Validate();
        }
        public void ChangeName(string name)
        {
            Name = name;
            Validate();
        }
        public void ChangeAvatar(string avatar)
        {
            Avatar = avatar;
            Validate();
        }

        private void Validate()
        {
            DomainValidation.IsNull(Name, nameof(Name));
            DomainValidation.IsNull(Email, nameof(Email));
            DomainValidation.IsNull(Password, nameof(Password));
            DomainValidation.HasGreaterThan(Avatar, MAX_AVATAR_LENGTH, nameof(Avatar));
        }
    }
}
