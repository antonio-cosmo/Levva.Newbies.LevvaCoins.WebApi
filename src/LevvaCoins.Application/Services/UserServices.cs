using LevvaCoins.Application.Exceptions;
using LevvaCoins.Application.Services.Dtos.User;
using LevvaCoins.Application.Services.Interfaces;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.SeedWork;

namespace LevvaCoins.Application.Services;
public class UserServices : IUserServices
{
    private readonly IUnitOfWork _unitOfWork;

    public UserServices(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<UserModelResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        var users = await _unitOfWork.UserRepository.GetAllAsync(cancellationToken);
        return UserModelResponse.FromDomain(users);
    }

    public async Task<UserModelResponse> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.UserRepository.GetAsync(id, cancellationToken)
            ?? throw new ModelNotFoundException("Esse usuário não existe.");
        return UserModelResponse.FromDomain(user);
    }

    public async Task<UserModelResponse> InsertAsync(CreateUserRequest request, CancellationToken cancellationToken)
    {
        await ValidateUserAlreadyExists(request.Email, cancellationToken);

        var newUser = new User(
                request.Name,
                request.Email,
                request.Password,
                request.Avatar
            );

        await _unitOfWork.UserRepository.InsertAsync(newUser, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
        return UserModelResponse.FromDomain(newUser);
    }

    public async Task RemoveAsync(Guid id, CancellationToken cancellationToken)
    {
        var userFound = await FindUser(id, cancellationToken);

        await _unitOfWork.UserRepository.RemoveAsync(userFound, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
    }

    public async Task UpdateAsync(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var user = await FindUser(request.Id, cancellationToken);

        user.ChangeName(request.Name);
        user.ChangeAvatar(request.Avatar);

        await _unitOfWork.UserRepository.UpdateAsync(user, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
    }
    private async Task ValidateUserAlreadyExists(string email, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.UserRepository.GetByEmailAsync(email, cancellationToken);
        if (user is not null)
        {
            throw new ModelAlreadyExistsException("Esse e-mail já existe.");
        }
    }
    private async Task<User> FindUser(Guid id, CancellationToken cancellationToken)
    {
        return await _unitOfWork.UserRepository.GetAsync(id, cancellationToken)
            ?? throw new ModelNotFoundException("Esse usuário não existe.");
    }
}
