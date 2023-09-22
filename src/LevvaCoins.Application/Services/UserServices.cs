using LevvaCoins.Application.Commands.Requests.User;
using LevvaCoins.Application.Common;
using LevvaCoins.Application.Responses;
using LevvaCoins.Application.Services.Interfaces;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.SeedWork;

namespace LevvaCoins.Application.Services;

public class UserServices : IUserServices
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly NotificationContext _notificationContext;

    public UserServices(IUnitOfWork unitOfWork, NotificationContext notificationContext)
    {
        _unitOfWork = unitOfWork;
        _notificationContext = notificationContext;
    }

    public async Task<IEnumerable<UserModelResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        var users = await _unitOfWork.UserRepository.GetAllAsync(cancellationToken);
        return UserModelResponse.FromDomain(users);
    }

    public async Task<UserModelResponse> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.UserRepository.GetByIdAsync(id, cancellationToken);
        
        if (user is not null)
            return UserModelResponse.FromDomain(user);
        
        _notificationContext.AddNotification("Excption","Esse usuário não existe.");
        return null;
        
    }

    public async Task<UserModelResponse> InsertAsync(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var userAlreadyExists = await ValidateUserAlreadyExists(request.Email, cancellationToken);
        
        if (userAlreadyExists)
        {
            _notificationContext.AddNotification("Excption", "Esse e-mail já existe.");
            return null;
        }

        var newUser = new User(
            request.Name,
            request.Email,
            request.Password,
            request.Avatar
        );
        if (!newUser.IsValid)
        {
            _notificationContext.AddNotifications(newUser.Notifications);
            return null;
        }
        await _unitOfWork.UserRepository.InsertAsync(newUser, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
        return UserModelResponse.FromDomain(newUser);
    }

    public async Task RemoveAsync(Guid id, CancellationToken cancellationToken)
    {
        var userFound = await FindUser(id, cancellationToken);
        if (userFound is null)
        {
            _notificationContext.AddNotification("Excption","Esse usuário não existe.");
            return;
        }
        
        await _unitOfWork.UserRepository.RemoveAsync(userFound, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
    }

    public async Task UpdateAsync(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var user = await FindUser(request.Id, cancellationToken);
        if (user is null)
        {
            _notificationContext.AddNotification("Excption","Esse usuário não existe.");
            return;
        }
        
        user.ChangeName(request.Name);
        user.ChangeAvatar(request.Avatar);

        if (!user.IsValid)
        {
            _notificationContext.AddNotifications(user.Notifications);
            return;
        }

        await _unitOfWork.UserRepository.UpdateAsync(user, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
    }

    private async Task<bool> ValidateUserAlreadyExists(string email, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.UserRepository.GetByPredicateAsync(x => x.Email == email, cancellationToken);
        return user is not null;
    }

    private async Task<User?> FindUser(Guid id, CancellationToken cancellationToken)
    {
        return await _unitOfWork.UserRepository.GetByIdAsync(id, cancellationToken);
        
    }
}