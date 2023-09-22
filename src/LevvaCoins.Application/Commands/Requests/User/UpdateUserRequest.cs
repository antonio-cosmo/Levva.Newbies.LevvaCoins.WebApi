using MediatR;

namespace LevvaCoins.Application.Commands.Requests.User;

public class UpdateUserRequest : IRequest
{
    public UpdateUserRequest(Guid id, string name, string avatar)
    {
        Id = id;
        Name = name;
        Avatar = avatar;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Avatar { get; set; }
}