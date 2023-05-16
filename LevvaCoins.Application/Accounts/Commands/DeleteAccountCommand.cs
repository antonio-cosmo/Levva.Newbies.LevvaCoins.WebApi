using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Interfaces.Repositories;
using MediatR;

namespace LevvaCoins.Application.Accounts.Commands
{
    public class DeleteAccountCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteAccountCommand(Guid id)
        {
            Id = id;
        }
    }

    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand>
    {
        readonly IUserRepository _userRepository;

        public DeleteAccountCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var accountAlreadExists = await _userRepository.GetByIdAsync(request.Id);
            if (accountAlreadExists is null) throw new ModelNotFoundException("Esse usuário não existe.");

            await _userRepository.RemoveAsync(accountAlreadExists);
        }
    }
}
