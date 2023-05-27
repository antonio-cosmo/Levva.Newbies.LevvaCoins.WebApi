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
            CreateMap<CreateAccountDto, CreateAccountCommand>().ReverseMap();
            CreateMap<UpdateAccountDto, UpdateAccoutCommand>().ReverseMap();
            CreateMap<CreateAccountCommand, User>().ReverseMap();
            CreateMap<UpdateAccoutCommand, User>().ReverseMap();
            CreateMap<AccountWithTokenDto, User>().ReverseMap();
            CreateMap<AccountDto, User>().ReverseMap();
        }
    }
}
