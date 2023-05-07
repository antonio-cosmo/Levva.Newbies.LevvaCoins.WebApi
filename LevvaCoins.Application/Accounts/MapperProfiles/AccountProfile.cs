using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LevvaCoins.Application.Accounts.Dtos;
using LevvaCoins.Domain.Entities;

namespace LevvaCoins.Application.Accounts.MapperProfiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<CreateAccountDto, User>();
            CreateMap<UpdateAccountDto, User>();
            CreateMap<User, AccountWithTokenDto>();
            CreateMap<User, AccountDto>();
        }
    }
}
