using MediatR;

namespace LevvaCoins.Application.Commands.Requests.User;

public class RemoveUserRequest : IRequest
{
    public RemoveUserRequest(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}