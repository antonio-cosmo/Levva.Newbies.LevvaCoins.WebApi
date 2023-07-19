using LevvaCoins.Application.UseCases.Users.Common;
using MediatR;

namespace LevvaCoins.Application.UseCases.Users.CreateUser;

public interface ICreateUser : IRequestHandler<CreateUserInput, UserOutput>
{
}
