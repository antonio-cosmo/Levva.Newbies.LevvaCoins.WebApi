using LevvaCoins.Application.Exceptions;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.SeedWork;

namespace LevvaCoins.Application.UseCases.Users.UpdateUser;

public class UpdateUser : IUpdateUser
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUser(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateUserInput request, CancellationToken cancellationToken)
    {
        var user = await FindUser(request.Id, cancellationToken);

        user.ChangeName(request.Name);
        user.ChangeAvatar(request.Avatar);

        await _unitOfWork.UserRepository.UpdateAsync(user, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
    }
    private async Task<User> FindUser(Guid id, CancellationToken cancellationToken)
    {
        return await _unitOfWork.UserRepository.GetAsync(id, cancellationToken) 
            ?? throw new ModelNotFoundException("Esse usuário não existe.");
    }
}
