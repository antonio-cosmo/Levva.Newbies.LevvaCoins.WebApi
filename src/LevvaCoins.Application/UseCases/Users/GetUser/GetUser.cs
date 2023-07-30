using LevvaCoins.Application.Services.Dtos.User;
using MediatR;

namespace LevvaCoins.Application.UseCases.Users.GetUser;

public class GetUser : IRequest<UserModelResponse?>
{
    public Guid Id { get; set; }

    public GetUser(Guid id)
    {
        Id = id;
    }
}
