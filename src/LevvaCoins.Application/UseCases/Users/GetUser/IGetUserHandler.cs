using LevvaCoins.Application.Services.Dtos.User;
using MediatR;

namespace LevvaCoins.Application.UseCases.Users.GetUser;

public interface IGetUserHandler : IRequestHandler<GetUser, UserModelResponse?>
{
}
