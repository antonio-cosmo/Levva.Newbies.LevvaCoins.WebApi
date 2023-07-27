using AutoMapper;
using LevvaCoins.Application.Exceptions;
using LevvaCoins.Application.UseCases.Users.Common;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.SeedWork;

namespace LevvaCoins.Application.UseCases.Users.CreateUser
{
    public class CreateUser : ICreateUser
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateUser(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserModelOutput> Handle(CreateUserInput request, CancellationToken cancellationToken)
        {
            await ValidateUserAlreadyExists(request.Email, cancellationToken);

            var newUser = new User(
                    request.Name,
                    request.Email,
                    request.Password,
                    request.Avatar
                );

            await _unitOfWork.UserRepository.InsertAsync(newUser, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            return UserModelOutput.FromDomain(newUser);
        }
        private async Task ValidateUserAlreadyExists(string email, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetByEmailAsync(email, cancellationToken);
            if (user is not null)
            {
                throw new ModelAlreadyExistsException("Esse e-mail já existe.");
            }
        }
    }
}
