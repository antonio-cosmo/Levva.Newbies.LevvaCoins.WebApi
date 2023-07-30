using LevvaCoins.Application.Services.Dtos.User;
using MediatR;

namespace LevvaCoins.Application.UseCases.Users.GetAllUser;
public interface IGetAllUsersHandler : IRequestHandler<GetAllUsers, IEnumerable<UserModelResponse>>
{
}
