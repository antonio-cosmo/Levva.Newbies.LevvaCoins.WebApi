using LevvaCoins.Application.UseCases.Users.Common;
using MediatR;

namespace LevvaCoins.Application.UseCases.Users.GetUser;

public interface IGetUser : IRequestHandler<GetUserInput, UserModelOutput?>
{
}
