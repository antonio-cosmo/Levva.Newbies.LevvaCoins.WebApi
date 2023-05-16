using AutoMapper;
using LevvaCoins.Application.Accounts.Commands;
using LevvaCoins.Application.Accounts.Dtos;
using LevvaCoins.Domain.Entities;

namespace LevvaCoins.Application.Accounts.MapperProfiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<CreateAccountDto, CreateAccountCommand>();
            CreateMap<CreateAccountCommand, User>();
            CreateMap<UpdateAccountDto, User>();
            CreateMap<User, AccountWithTokenDto>();
            CreateMap<User, AccountDto>();
        }
    }
}
