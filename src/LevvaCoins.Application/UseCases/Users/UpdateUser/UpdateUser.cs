using LevvaCoins.Application.Exceptions;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Repositories;
using LevvaCoins.Domain.SeedWork;
using MediatR;

namespace LevvaCoins.Application.UseCases.Users.UpdateUser
{
    public class UpdateUser : IUpdateUser
    {
        private readonly IUserRepository _userRepository;
        private IUnitOfWork _unitOfWork;

        public UpdateUser(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateUserInput request, CancellationToken cancellationToken)
        {
            var user = await FindUser(request.Id, cancellationToken);

            user.ChangeName(request.Name);
            user.ChangeAvatar(request.Avatar);

            await _userRepository.UpdateAsync(user, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
        }
        private async Task<User> FindUser(Guid id, CancellationToken cancellationToken)
        {
            return await _userRepository.GetAsync(id, cancellationToken) 
                ?? throw new ModelNotFoundException("Esse usuário não existe.");
        }
    }
}
