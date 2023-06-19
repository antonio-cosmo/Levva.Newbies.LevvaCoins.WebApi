using AutoMapper;
using LevvaCoins.Application.Users.Commands;
using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Interfaces.Repositories;
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
            try
            {
                var userAlreadyExists = await _userRepository.GetByEmailAsync(request.Email);
                if (userAlreadyExists is not null)
                    throw new ModelAlreadyExistsException("Esse e-mail já existe");

                var newUser = _mapper.Map<User>(request);
                newUser.Validate();

                return await _userRepository.SaveAsync(newUser);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
