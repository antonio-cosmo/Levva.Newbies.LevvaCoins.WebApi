namespace LevvaCoins.Application.Services.Dtos.User;
public class UpdateUserRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Avatar { get; set; }

    public UpdateUserRequest(Guid id, string name, string avatar)
    {
        Id = id;
        Name = name;
        Avatar = avatar;
    }
}
