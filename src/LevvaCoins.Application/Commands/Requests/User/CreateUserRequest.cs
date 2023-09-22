using LevvaCoins.Application.Responses;
using MediatR;

namespace LevvaCoins.Application.Commands.Requests.User;

public class CreateUserRequest : IRequest<UserModelResponse>
{
    public CreateUserRequest(string name, string email, string password, string avatar)
    {
        Name = name;
        Email = email;
        Password = password;
        Avatar = avatar;
    }

    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Avatar { get; set; }
}