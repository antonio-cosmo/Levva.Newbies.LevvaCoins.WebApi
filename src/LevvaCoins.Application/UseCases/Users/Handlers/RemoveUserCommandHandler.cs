using LevvaCoins.Application.UseCases.Users.Commands;
using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Repositories;
using MediatR;

namespace LevvaCoins.Application.UseCases.Users.Handlers
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
            var userExists = await _userRepository.GetAsync(request.Id, cancellationToken)
                ?? throw new ModelNotFoundException("Esse usuário não existe.");

            await _userRepository.RemoveAsync(userExists, cancellationToken);

        }
    }
}
