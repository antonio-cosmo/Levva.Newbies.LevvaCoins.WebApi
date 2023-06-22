using LevvaCoins.Application.Users.Commands;
using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Entities;
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
            var user = await GetUserById(request.Id);

            user.Update(request.Name, request.Avatar);
            ValidateUser(user);

            await _userRepository.UpdateAsync(user);
        }
        private async Task<User> GetUserById(Guid id)
        {
            return await _userRepository.GetByIdAsync(id) ?? throw new ModelNotFoundException("Esse usuário não existe.");
        }
        private static void ValidateUser(User user)
        {
            if (!user.IsValid())
            {
                throw new DomainValidationException("Entidade invalida.");
            }
        }
    }
}
