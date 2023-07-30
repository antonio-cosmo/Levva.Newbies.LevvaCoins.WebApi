using LevvaCoins.Application.Services.Dtos.User;
using MediatR;

namespace LevvaCoins.Application.UseCases.Users.GetAllUser;

public class GetAllUsers : IRequest<IEnumerable<UserModelResponse>>
{
}
