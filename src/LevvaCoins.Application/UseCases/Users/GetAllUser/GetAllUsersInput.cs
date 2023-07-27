using LevvaCoins.Application.UseCases.Users.Common;
using MediatR;

namespace LevvaCoins.Application.UseCases.Users.GetAllUser
{
    public class GetAllUsersInput : IRequest<IEnumerable<UserModelOutput>>
    {
    }
}
