namespace LevvaCoins.Application.Users.Dtos
{
    public class LoginResponseDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Avatar { get; set; }
        public string? Token { get; set; }
    }
}
