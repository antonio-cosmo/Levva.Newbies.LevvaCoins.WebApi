namespace LevvaCoins.Application.Services.Dtos.User;
public class UserAuthenticateModelResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string? Avatar { get; set; }
    public string? Token { get; set; }

    public UserAuthenticateModelResponse(Guid id, string name, string email, string? avatar, string token)
    {
        Id = id;
        Name = name;
        Email = email;
        Avatar = avatar;
        Token = token;
    }
}
