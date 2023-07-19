using LevvaCoins.Application.UseCases.Users.Common;
using MediatR;

namespace LevvaCoins.Application.UseCases.Users.GetAllUser;
public interface IGetAllUsers : IRequestHandler<GetAllUsersInput, IEnumerable<UserOutput>>
{
}
