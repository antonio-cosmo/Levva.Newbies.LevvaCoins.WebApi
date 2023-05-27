namespace LevvaCoins.Application.Accounts.Dtos
{
    public class CreateAccountDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;

    }
}
