using AutoMapper;
using LevvaCoins.Application.Utils;
using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Interfaces.Repositories;
using MediatR;

namespace LevvaCoins.Application.Accounts.Commands
{
    public class SaveAccountCommand : IRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }

        public SaveAccountCommand(string name, string email, string password, string avatar)
        {
            Name = name;
            Email = email;
            Password = HashFunction.Generate(password); ;
            Avatar = avatar;
        }
    }

    public class CreateAccountCommandHandler : IRequestHandler<SaveAccountCommand>
    {
        readonly IUserRepository _userRepository;
        readonly IMapper _mapper;

        public CreateAccountCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task Handle(SaveAccountCommand request, CancellationToken cancellationToken)
        {
            var account = await _userRepository.GetByEmailAsync(request.Email);
            
            if (account is not null) throw new ModelAlreadyExistsException("Esse e-mail já existe");

            await _userRepository.SaveAsync(_mapper.Map<User>(request));
        }
    }
}
