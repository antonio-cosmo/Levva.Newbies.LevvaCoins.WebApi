using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Interfaces.Repositories;
using MediatR;

namespace LevvaCoins.Application.Accounts.Commands
{
    public class UpdateAccoutCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }

        public UpdateAccoutCommand(Guid id, string name, string avatar)
        {
            Id = id;
            Name = name;
            Avatar = avatar;
        }
    }

    public class UpdateAccoutCommandHandler : IRequestHandler<UpdateAccoutCommand>
    {
        readonly IUserRepository _userRepository;

        public UpdateAccoutCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(UpdateAccoutCommand request, CancellationToken cancellationToken)
        {
            var account = await _userRepository.GetByIdAsync(request.Id);
            if (account is null) throw new ModelNotFoundException("Esse usuário não existe.");

            account.Update(
                name: request.Name,
                avatar: request.Avatar
            );

            await _userRepository.UpdateAsync(account);
        }
    }
}
