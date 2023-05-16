using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LevvaCoins.Application.Accounts.Dtos;
using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Interfaces.Repositories;
using MediatR;

namespace LevvaCoins.Application.Accounts.Commands
{
    public class UpdateAccoutCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }

        public UpdateAccoutCommand(Guid id, string name, string avatar)
        {
            Id = id;
            Name = name;
            Avatar = avatar;
        }
    }

    public class UpdateAccoutCommandHandler : IRequestHandler<UpdateAccoutCommand>
    {
        readonly IUserRepository _userRepository;
        readonly IMapper _mapper;

        public UpdateAccoutCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateAccoutCommand request, CancellationToken cancellationToken)
        {
            var accountAlreadyExists = await _userRepository.GetByIdAsync(request.Id);
            if (accountAlreadyExists is null) throw new ModelNotFoundException("Esse usuário não existe.");

            accountAlreadyExists.Update(
                name: request.Name,
                avatar: request.Avatar
            );

            await _userRepository.UpdateAsync(accountAlreadyExists);
        }
    }
}
