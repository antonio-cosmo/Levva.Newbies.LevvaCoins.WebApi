using AutoMapper;
using LevvaCoins.Application.Exceptions;
using LevvaCoins.Application.UseCases.Users.Common;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Repositories;
using LevvaCoins.Domain.SeedWork;
using MediatR;

namespace LevvaCoins.Application.UseCases.Users.CreateUser
{
    public class CreateUser : ICreateUser
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUser(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserOutput> Handle(CreateUserInput request, CancellationToken cancellationToken)
        {
            await ValidateUserAlreadyExists(request.Email, cancellationToken);

            var newUser = _mapper.Map<User>(request);

            await _userRepository.InsertAsync(newUser, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            return UserOutput.FromDomain(newUser);
        }
        private async Task ValidateUserAlreadyExists(string email, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(email, cancellationToken);
            if (user is not null)
            {
                throw new ModelAlreadyExistsException("Esse e-mail já existe.");
            }
        }
    }
}
