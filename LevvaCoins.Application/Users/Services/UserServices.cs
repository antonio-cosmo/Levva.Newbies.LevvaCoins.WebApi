using AutoMapper;
using LevvaCoins.Application.Users.Commands;
using LevvaCoins.Application.Users.Dtos;
using LevvaCoins.Application.Users.Interfaces;
using LevvaCoins.Application.Users.Queries;
using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Entities;
using MediatR;

namespace LevvaCoins.Application.Users.Services
{
    public class UserServices : IUserServices
    {
        readonly IMediator _mediator;
        readonly IMapper _mapper;

        public UserServices(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<UserDto> SaveAsync(CreateUserDto createUserDto)
        {
            var saveCommand = _mapper.Map<SaveUserCommand>(createUserDto);
            return _mapper.Map<UserDto>(await _mediator.Send(saveCommand));
        }

        public async Task RemoveAsync(Guid id)
        {
            var removeCommand = new RemoveUserCommand(id);
            await _mediator.Send(removeCommand);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            var queryByEmail = new GetUserByEmailQuery(email);
            return await _mediator.Send(queryByEmail);
        }

        public async Task<UserDto> GetByIdAsync(Guid id)
        {
            var queryById = new GetUserByIdQuery(id);

            var account = await _mediator.Send(queryById)
                ?? throw new ModelNotFoundException("Esse usuário não existe.");

            return _mapper.Map<UserDto>(account);
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var queryAll = new GetAllUserQuery();
            
            var accounts = await _mediator.Send(queryAll);

            return _mapper.Map<IEnumerable<UserDto>>(accounts);
        }

        public async Task UpdateAsync(Guid id, UpdateUserDto updateUserDto)
        {
            var updateCommand = new UpdateUserCommand(
                id,
                name: updateUserDto.Name
                                ?? throw new ArgumentException("Atributo nome nulo", nameof(updateUserDto.Name)),
                avatar: updateUserDto.Avatar
                                ?? throw new ArgumentException("Atributo avatar nulo", nameof(updateUserDto.Avatar))
            );

            await _mediator.Send(updateCommand);
        }
    }
}
