using MediatR;

namespace LevvaCoins.Application.UseCases.Users.UpdateUser;

public class UpdateUserInput : IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Avatar { get; set; }

    public UpdateUserInput(Guid id, string name, string avatar)
    {
        Id = id;
        Name = name;
        Avatar = avatar;
    }
}
