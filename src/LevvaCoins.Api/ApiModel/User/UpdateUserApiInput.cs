namespace LevvaCoins.Api.ApiModel.User;

public class UpdateUserApiInput
{
    public string Name { get; set; }
    public string Avatar { get; set; }

    public UpdateUserApiInput(string name, string avatar)
    {
        Name = name;
        Avatar = avatar;
    }
}
