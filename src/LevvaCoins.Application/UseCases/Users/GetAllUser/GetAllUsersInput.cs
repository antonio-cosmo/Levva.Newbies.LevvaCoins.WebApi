using LevvaCoins.Application.UseCases.Users.Common;
using LevvaCoins.Domain.Entities;
using MediatR;

namespace LevvaCoins.Application.UseCases.Users.GetAllUser
{
    public class GetAllUsersInput : IRequest<IEnumerable<UserOutput>>
    {
    }
}
