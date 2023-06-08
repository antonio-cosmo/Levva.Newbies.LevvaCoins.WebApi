using AutoMapper;
using LevvaCoins.Application.Accounts.Commands;
using LevvaCoins.Application.Accounts.Dtos;
using LevvaCoins.Application.Accounts.Interfaces;
using LevvaCoins.Application.Accounts.Queries;
using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Entities;
using MediatR;

namespace LevvaCoins.Application.Accounts.Services
{
    public class AccountServices : IAccountServices
    {
        readonly IMediator _mediator;
        readonly IMapper _mapper;

        public AccountServices(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task SaveAsync(SaveAccountDto accountDto)
        {
            var saveCommand = _mapper.Map<SaveAccountCommand>(accountDto);
            await _mediator.Send(saveCommand);
        }

        public async Task RemoveAsync(Guid id)
        {
            var removeCommand = new RemoveAccountCommand(id);
            await _mediator.Send(removeCommand);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            var queryByEmail = new GetAccountByEmailQuery(email);
            return await _mediator.Send(queryByEmail);
        }

        public async Task<AccountDto> GetByIdAsync(Guid id)
        {
            var queryById = new GetAccountByIdQuery(id);
            var account = await _mediator.Send(queryById);
            
            if(account is null) throw new ModelNotFoundException("Esse usuário não existe.");

            return _mapper.Map<AccountDto>(account);
        }

        public async Task<IEnumerable<AccountDto>> GetAllAsync()
        {
            var queryAll = new GetAllAccountQuery();
            
            var accounts = await _mediator.Send(queryAll);

            return _mapper.Map<IEnumerable<AccountDto>>(accounts);
        }

        public async Task UpdateAsync(Guid id, UpdateAccountDto accountDto)
        {
            var updateCommand = new UpdateAccoutCommand(id, accountDto.Name, accountDto.Avatar);
            await _mediator.Send(updateCommand);
        }
    }
}
