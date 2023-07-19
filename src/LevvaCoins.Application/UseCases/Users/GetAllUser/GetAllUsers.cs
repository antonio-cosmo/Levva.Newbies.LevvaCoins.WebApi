using LevvaCoins.Application.UseCases.Users.Common;
using LevvaCoins.Domain.Repositories;
using MediatR;

namespace LevvaCoins.Application.UseCases.Users.GetAllUser;
public class GetAllUsers : IGetAllUsers
{
    private readonly IUserRepository _userRepository;

    public GetAllUsers(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<UserOutput>> Handle(GetAllUsersInput request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync(cancellationToken);
        return UserOutput.FromDomain(users);
    }
}
