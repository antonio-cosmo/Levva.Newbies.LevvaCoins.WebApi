using AutoMapper;
using LevvaCoins.Application.UseCases.Categories.CreateCategory;
using LevvaCoins.Application.UseCases.Transactions.Common;
using LevvaCoins.Application.UseCases.Transactions.CreateTransaction;
using LevvaCoins.Application.UseCases.Transactions.UpdateTransaction;
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
            CreateMap<CreateCategoryInput, Category>();
                //.ForMember(dest => dest.Description, opt => opt.MapFrom(src=> new Description(src.Description)));

            //User
            CreateMap<CreateUserInput, User>().ReverseMap();
            CreateMap<User, AuthenticateUserOutput>().ReverseMap();

            //Transaction
            CreateMap<CreateTransactionInput, Transaction>();
            //.ForMember(dest => dest.Description, opt => opt.MapFrom(src => new Description(src.Description)));
            CreateMap<Transaction, TransactionDetailsOutput>();
                //.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description.Text));
            CreateMap<PagedResult<Transaction>, PagedResult<TransactionDetailsOutput>>();
        }
    }
}
