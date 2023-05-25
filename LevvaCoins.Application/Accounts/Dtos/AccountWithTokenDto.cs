namespace LevvaCoins.Application.Accounts.Dtos
{
    public class AccountWithTokenDto
    {
        public Guid Id { get; set; }
        public string Token { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;
    }
}
