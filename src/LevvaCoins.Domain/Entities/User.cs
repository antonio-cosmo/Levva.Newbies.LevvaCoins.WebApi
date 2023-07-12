using System.Diagnostics.Contracts;
using LevvaCoins.Domain.Shared.Entities;
using LevvaCoins.Domain.Shared.Validations;

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
        private User() { }
        public User(string name, string email, string password, string? avatar = null)
        {
            Name = name;
            Email = email;
            Password = password;
            Avatar = avatar;
            Transactions = new List<Transaction>();

            AddNotifications(
                    new ValidationRule().Requires().IsNotNull(Name, nameof(Name), "should not be null"),
                    new ValidationRule().Requires().IsNotNull(Email, nameof(Email), "should not be null"),
                    new ValidationRule().Requires().IsNotNull(Password, nameof(Password), "should not be null"),
                    new ValidationRule().Requires().HasLowerThan(Avatar, MAX_AVATAR_LENGTH, nameof(Avatar), $"should have more than {MAX_AVATAR_LENGTH} characters")

                );
        }
        public void ChangeName(string name)
        {
            Name = name;
            AddNotifications(
                    new ValidationRule().Requires().
                    IsNotNull(Name, nameof(Name), "should not be null")
                );
        }
        public void ChangeAvatar(string avatar)
        {
            Avatar = avatar;
            AddNotifications(
                    new ValidationRule().Requires().
                    HasLowerThan(Avatar, MAX_AVATAR_LENGTH, nameof(Avatar), $"should have more than {MAX_AVATAR_LENGTH} characters")
                );
        }
    }
}
