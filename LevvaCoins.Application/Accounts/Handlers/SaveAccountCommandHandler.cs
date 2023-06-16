using AutoMapper;
using LevvaCoins.Application.Accounts.Commands;
using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Interfaces.Repositories;
using MediatR;

namespace LevvaCoins.Application.Accounts.Handlers
{
    public class SaveAccountCommandHandler : IRequestHandler<SaveAccountCommand, User>
    {
        readonly IUserRepository _userRepository;
        readonly IMapper _mapper;

        public SaveAccountCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<User> Handle(SaveAccountCommand request, CancellationToken cancellationToken)
        {
            var account = await _userRepository.GetByEmailAsync(request.Email);

            if (account is not null) throw new ModelAlreadyExistsException("Esse e-mail já existe");

            return await _userRepository.SaveAsync(_mapper.Map<User>(request));
        }
    }
}
