using LevvaCoins.Application.Queries.Requests.User;
using LevvaCoins.Application.Responses;
using MediatR;

namespace LevvaCoins.Application.Queries.Interfaces.User;

public interface IGetAllUsersHandler : IRequestHandler<GetAllUsersRequest, IEnumerable<UserModelResponse>>
{
}