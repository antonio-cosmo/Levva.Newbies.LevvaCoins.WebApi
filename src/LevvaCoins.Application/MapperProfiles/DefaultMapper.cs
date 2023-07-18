using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LevvaCoins.Application.Categories.Dtos;
using LevvaCoins.Application.UseCases.Categories.Common;
using LevvaCoins.Application.UseCases.Categories.CreateCategory;
using LevvaCoins.Application.UseCases.Categories.UpdateCategory;
using LevvaCoins.Application.UseCases.Transactions.Commands;
using LevvaCoins.Application.UseCases.Transactions.Dtos;
using LevvaCoins.Application.UseCases.Users.Commands;
using LevvaCoins.Application.UseCases.Users.Dtos;
using LevvaCoins.Domain.Common;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.ValueObjects;

namespace LevvaCoins.Application.MapperProfiles
{
    public class DefaultMapper : Profile
    {
        public DefaultMapper()
        {
            //Category
            CreateMap<CreateCategoryInput, Category>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src=> new Description(src.Description)));

            //User
            CreateMap<CreateUserDto, SaveUserCommand>().ReverseMap();
            CreateMap<UpdateUserDto, UpdateUserCommand>().ReverseMap();
            CreateMap<SaveUserCommand, User>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User,LoginResponseDto>().ReverseMap();

            //Transaction
            CreateMap<CreateTransactionDto, SaveTransactionCommand>().ReverseMap();
            CreateMap<UpdateTransactionDto, UpdateTransactionCommand>().ReverseMap();
            CreateMap<SaveTransactionCommand, Transaction>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => new Description(src.Description)));
            CreateMap<Transaction, TransactionDetailsDto>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description.Text));
            CreateMap<PagedResult<Transaction>, PagedResult<TransactionDetailsDto>>();
        }
    }
}
