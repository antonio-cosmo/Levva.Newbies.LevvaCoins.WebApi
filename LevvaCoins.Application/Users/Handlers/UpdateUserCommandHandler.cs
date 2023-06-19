using LevvaCoins.Application.Users.Commands;
using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Interfaces.Repositories;
using MediatR;

namespace LevvaCoins.Application.Users.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userExists = await _userRepository.GetByIdAsync(request.Id)
                    ?? throw new ModelNotFoundException("Esse usuário não existe.");

                userExists.Update(request.Name, request.Avatar);
                userExists.Validate();

                await _userRepository.UpdateAsync(userExists);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
