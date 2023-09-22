using LevvaCoins.Application.Responses;
using MediatR;

namespace LevvaCoins.Application.Queries.Requests.User;

public class GetAllUsersRequest : IRequest<IEnumerable<UserModelResponse>>
{
}