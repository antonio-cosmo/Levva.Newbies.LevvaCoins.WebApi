using LevvaCoins.Application.Services.Dtos.User;
using MediatR;

namespace LevvaCoins.Application.UseCases.Users.CreateUser;

public interface ICreateUserHandler : IRequestHandler<CreateUser, UserModelResponse>
{
}
