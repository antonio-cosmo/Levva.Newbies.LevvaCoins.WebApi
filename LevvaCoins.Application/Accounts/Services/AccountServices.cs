using AutoMapper;
using LevvaCoins.Application.Accounts.Dtos;
using LevvaCoins.Application.Accounts.Interfaces;
using LevvaCoins.Application.Utils;
using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Interfaces.Repositories;

namespace LevvaCoins.Application.Accounts.Services
{
    public class AccountServices : IAccountServices
    {
        readonly IUserRepository _userRepository;
        readonly IMapper _mapper;

        public AccountServices(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task CreateAccountAsync(CreateAccountDto accountDto)
        {
            var accountAlreadyExists = await _userRepository.GetByEmailAsync(accountDto.Email);
            if (accountAlreadyExists != null) throw new ModelAlreadyExistsException("Esse e-mail já existe");
            accountDto.Password = HashFunction.Generate(accountDto.Password!);
            var account = _mapper.Map<User>(accountDto);
            await _userRepository.SaveAsync(account);
        }

        public async Task DeleteAccountAsync(Guid id)
        {
            var success = await _userRepository.DeleteByIdAsync(id);
            if (!success) throw new ModelNotFoundException("Esse usuário não existe.");
        }

        public async Task<User> GetAccountByEmailAsync(string email)
        {
            var account = await _userRepository.GetByEmailAsync(email);
            if (account == null) throw new ModelNotFoundException("Esse usuário não existe.");
            return account;
        }

        public async Task<AccountDto> GetAccountByIdAsync(Guid id)
        {
            var account = await _userRepository.GetByIdAsync(id);
            if (account == null) throw new ModelNotFoundException("Esse usuário não existe.");
            return _mapper.Map<AccountDto>(account);
        }

        public async Task<IEnumerable<AccountDto>> GetAllAccountAsync()
        {
            var accountList = await _userRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<AccountDto>>(accountList);
        }

        public async Task UpdateAccountAsync(Guid id, UpdateAccountDto accountDto)
        {
            var accountAlreadyExists = await _userRepository.GetByIdAsync(id);
            if (accountAlreadyExists == null) throw new ModelNotFoundException("Esse usuário não existe.");
    
            accountAlreadyExists.UpdateEntity(name: accountDto.Name, avatar: accountDto.Avatar);

            await _userRepository.UpdateAsync(accountAlreadyExists);
        }
    }
}
