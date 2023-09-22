using LevvaCoins.Application.Responses;
using MediatR;

namespace LevvaCoins.Application.Queries.Requests.User;

public class GetUserRequest : IRequest<UserModelResponse?>
{
    public GetUserRequest(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}