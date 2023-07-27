using LevvaCoins.Application.Exceptions;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.SeedWork;

namespace LevvaCoins.Application.UseCases.Users.RemoveUser;

public class RemoveUser : IRemoveUser
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoveUser(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(RemoveUserInput request, CancellationToken cancellationToken)
    {
        var userFound = await FindUser(request.Id, cancellationToken);

        await _unitOfWork.UserRepository.RemoveAsync(userFound, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
    }
    private async Task<User> FindUser(Guid id, CancellationToken cancellationToken)
    {
        return await _unitOfWork.UserRepository.GetAsync(id, cancellationToken)
            ?? throw new ModelNotFoundException("Esse usuário não existe.");
    }
}
