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

        public async Task CreateAccountAsync(CreateAccountDto accountDto)
        {
            var command = _mapper.Map<CreateAccountCommand>(accountDto);

            await _mediator.Send(command);
        }

        public async Task DeleteAccountAsync(Guid id)
        {
            var command = new DeleteAccountCommand(id);
            await _mediator.Send(command);
        }

        public async Task<User?> GetAccountByEmailAsync(string email)
        {
            var query = new GetAccountByEmailQuery(email);
            return await _mediator.Send(query);
        }

        public async Task<AccountDto> GetAccountByIdAsync(Guid id)
        {
            var query = new GetAccountByIdQuery(id);
            var result = await _mediator.Send(query);
            if(result is null) throw new ModelNotFoundException("Esse usuário não existe.");
            return _mapper.Map<AccountDto>(result);
        }

        public async Task<IEnumerable<AccountDto>> GetAllAccountAsync()
        {
            var query = new GetAllAccountQuery();
            var accountList = await _mediator.Send(query);

            return _mapper.Map<IEnumerable<AccountDto>>(accountList);
        }

        public async Task UpdateAccountAsync(Guid id, UpdateAccountDto accountDto)
        {
            var command = new UpdateAccoutCommand(id, accountDto.Name, accountDto.Avatar);
            await _mediator.Send(command);
        }
    }
}
