using AutoMapper;
using LevvaCoins.Application.UseCases.Users.Commands;
using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Repositories;
using MediatR;

namespace LevvaCoins.Application.UseCases.Users.Handlers
{
    public class SaveUserCommandHandler : IRequestHandler<SaveUserCommand>
    {
        readonly IUserRepository _userRepository;
        readonly IMapper _mapper;

        public SaveUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task Handle(SaveUserCommand request, CancellationToken cancellationToken)
        {
            await ValidateUserAlreadyExists(request.Email, cancellationToken);

            var newUser = _mapper.Map<User>(request);

            await _userRepository.InsertAsync(newUser, cancellationToken);
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
