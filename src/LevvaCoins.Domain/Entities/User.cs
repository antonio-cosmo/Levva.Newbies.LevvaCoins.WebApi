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
        public IList<Transaction> Transactions { get; set; }

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

        protected override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
                AddNotification(nameof(Name), $"should not be null");
            if (string.IsNullOrWhiteSpace(Email))
                AddNotification(nameof(Email), $"should not be null");
            if (string.IsNullOrWhiteSpace(Password))
                AddNotification(nameof(Password), $"should not be null");
            if (Avatar is { Length: > MAX_AVATAR_LENGTH })
                AddNotification(nameof(Avatar), $"hould be less than {MAX_AVATAR_LENGTH}");
        }
    }
}