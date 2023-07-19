using MediatR;

namespace LevvaCoins.Application.UseCases.Users.UpdateUser;
public interface IUpdateUser : IRequestHandler<UpdateUserInput>
{
}
