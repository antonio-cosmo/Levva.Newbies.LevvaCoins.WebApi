using AutoMapper;
using LevvaCoins.Application.UseCases.Categories.CreateCategory;
using LevvaCoins.Application.UseCases.Transactions.Commands;
using LevvaCoins.Application.UseCases.Transactions.Dtos;
using LevvaCoins.Application.UseCases.Users.AuthenticateUser;
using LevvaCoins.Application.UseCases.Users.CreateUser;
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
            CreateMap<CreateUserInput, User>().ReverseMap();
            CreateMap<User, AuthenticateUserOutput>().ReverseMap();

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
