using LevvaCoins.Application.UseCases.Users.Common;
using LevvaCoins.Domain.SeedWork;

namespace LevvaCoins.Application.UseCases.Users.GetAllUser;
public class GetAllUsers : IGetAllUsers
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllUsers(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<UserModelOutput>> Handle(GetAllUsersInput request, CancellationToken cancellationToken)
    {
        var users = await _unitOfWork.UserRepository.GetAllAsync(cancellationToken);
        return UserModelOutput.FromDomain(users);
    }
}
