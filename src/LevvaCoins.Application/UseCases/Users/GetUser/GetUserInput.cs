using LevvaCoins.Application.UseCases.Users.Common;
using MediatR;

namespace LevvaCoins.Application.UseCases.Users.GetUser;

public class GetUserInput : IRequest<UserModelOutput?>
{
    public Guid Id { get; set; }

    public GetUserInput(Guid id)
    {
        Id = id;
    }
}
