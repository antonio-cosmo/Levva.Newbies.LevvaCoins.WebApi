using LevvaCoins.Application.Users.Commands;
using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Interfaces.Repositories;
using MediatR;

namespace LevvaCoins.Application.Users.Handlers
{
    public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommand>
    {
        readonly IUserRepository _userRepository;

        public RemoveUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(RemoveUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userExists = await _userRepository.GetByIdAsync(request.Id)
                    ?? throw new ModelNotFoundException("Esse usuário não existe.");

                await _userRepository.RemoveAsync(userExists);
            }catch(Exception)
            {
                throw;
            }    
        }
    }
}
