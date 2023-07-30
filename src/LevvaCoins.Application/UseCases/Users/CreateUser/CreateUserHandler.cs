using LevvaCoins.Application.Services.Dtos.User;
using LevvaCoins.Application.Services.Interfaces;
using LevvaCoins.Domain.SeedWork;

namespace LevvaCoins.Application.UseCases.Users.CreateUser;

public class CreateUserHandler : ICreateUserHandler
{
    private readonly IUserServices _userServices;

    public CreateUserHandler(IUserServices userServices)
    {
        _userServices = userServices;
    }

    public async Task<UserModelResponse> Handle(CreateUser request, CancellationToken cancellationToken)
    {
        var createRequest = new CreateUserRequest(
                request.Name,
                request.Email,
                request.Password,
                request.Avatar
            );
        return await _userServices.InsertAsync(createRequest, cancellationToken);
    }
    
}
