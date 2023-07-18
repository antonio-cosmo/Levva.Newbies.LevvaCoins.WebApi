using LevvaCoins.Application.UseCases.Users.Commands;
using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Repositories;
using MediatR;

namespace LevvaCoins.Application.UseCases.Users.Handlers
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
            var user = await GetUserById(request.Id, cancellationToken);

            user.ChangeName(request.Name);
            user.ChangeAvatar(request.Avatar);

            await _userRepository.UpdateAsync(user, cancellationToken);
        }
        private async Task<User?> GetUserById(Guid id, CancellationToken cancellationToken)
        {
            return await _userRepository.GetAsync(id, cancellationToken) ?? throw new ModelNotFoundException("Esse usuário não existe.");
        }
    }
}
