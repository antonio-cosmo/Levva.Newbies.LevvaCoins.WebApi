using LevvaCoins.Application.Commands.Interfaces.User;
using LevvaCoins.Application.Commands.Requests.User;
using LevvaCoins.Application.Responses;
using LevvaCoins.Application.Services.Interfaces;

namespace LevvaCoins.Application.Commands.Handlers.User;

public class CreateUserHandler : ICreateUserHandler
{
    private readonly IUserServices _userServices;

    public CreateUserHandler(IUserServices userServices)
    {
        _userServices = userServices;
    }

    public async Task<UserModelResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
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