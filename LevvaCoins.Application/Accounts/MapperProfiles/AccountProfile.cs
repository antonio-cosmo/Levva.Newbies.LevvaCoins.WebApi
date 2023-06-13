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
            CreateMap<SaveAccountDto, SaveAccountCommand>().ReverseMap();
            CreateMap<UpdateAccountDto, UpdateAccoutCommand>().ReverseMap();
            CreateMap<SaveAccountCommand, User>().ReverseMap();
            CreateMap<UpdateAccoutCommand, User>().ReverseMap();
            CreateMap<LoginResponseDto, User>().ReverseMap();
            CreateMap<AccountDto, User>().ReverseMap();
        }
    }
}
