using MediatR;

namespace LevvaCoins.Application.UseCases.Users.RemoveUser;

public class RemoveUser : IRequest
{
    public Guid Id { get; set; }

    public RemoveUser(Guid id)
    {
        Id = id;
    }
}
