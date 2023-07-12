using AutoMapper;
using LevvaCoins.Application.Users.Commands;
using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Repositories;
using MediatR;

namespace LevvaCoins.Application.Users.Handlers
{
    public class SaveUserCommandHandler : IRequestHandler<SaveUserCommand, User>
    {
        readonly IUserRepository _userRepository;
        readonly IMapper _mapper;

        public SaveUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<User> Handle(SaveUserCommand request, CancellationToken cancellationToken)
        {
            await ValidateUserAlreadyExists(request.Email);

            var newUser = _mapper.Map<User>(request);
            ValidateUser(newUser);

            return await _userRepository.InsertAsync(newUser);
        }
        private async Task ValidateUserAlreadyExists(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user is not null)
            {
                throw new ModelAlreadyExistsException("Esse e-mail já existe.");
            }
        }
        private static void ValidateUser(User user)
        {
            if (!user.IsValid)
            {
                throw new DomainValidationException("Entidade inválida");
            }
        }
    }
}
