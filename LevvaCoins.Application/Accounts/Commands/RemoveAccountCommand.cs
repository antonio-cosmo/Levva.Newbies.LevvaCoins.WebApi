using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Interfaces.Repositories;
using MediatR;

namespace LevvaCoins.Application.Accounts.Commands
{
    public class RemoveAccountCommand : IRequest
    {
        public Guid Id { get; set; }

        public RemoveAccountCommand(Guid id)
        {
            Id = id;
        }
    }

    public class DeleteAccountCommandHandler : IRequestHandler<RemoveAccountCommand>
    {
        readonly IUserRepository _userRepository;

        public DeleteAccountCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(RemoveAccountCommand request, CancellationToken cancellationToken)
        {
            var account = await _userRepository.GetByIdAsync(request.Id);

            if (account is null) throw new ModelNotFoundException("Esse usuário não existe.");

            await _userRepository.RemoveAsync(account);
        }
    }
}
