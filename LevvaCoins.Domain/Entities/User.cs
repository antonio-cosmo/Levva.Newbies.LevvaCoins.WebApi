namespace LevvaCoins.Domain.Entities
{
    public sealed class User : Entity
    {
        private const int MAX_AVATAR_LENGTH = 255;
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

        public override bool IsValid()
        {
            if (string.IsNullOrEmpty(Name))
                return false;
            if (string.IsNullOrEmpty(Email))
                return false;
            if (string.IsNullOrEmpty(Password))
                return false;
            if (Avatar?.Length > MAX_AVATAR_LENGTH)
                return false;

            return true;
        }
    }
}
