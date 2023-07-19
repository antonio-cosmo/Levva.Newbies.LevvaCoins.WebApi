using MediatR;

namespace LevvaCoins.Application.UseCases.Users.RemoveUser;

public interface IRemoveUser : IRequestHandler<RemoveUserInput>
{
}
