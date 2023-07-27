using AutoMapper;
using LevvaCoins.Application.UseCases.Categories.Common;
using LevvaCoins.Application.UseCases.Categories.CreateCategory;
using LevvaCoins.Application.UseCases.Transactions.Common;
using LevvaCoins.Application.UseCases.Transactions.CreateTransaction;
using LevvaCoins.Application.UseCases.Users.Common;
using LevvaCoins.Application.UseCases.Users.CreateUser;
using LevvaCoins.Application.UseCases.Users.UserAuthenticate;
using LevvaCoins.Domain.Entities;

namespace LevvaCoins.Application.MapperProfiles
{
    public class DefaultMapper : Profile
    {
        public DefaultMapper()
        {
            //Category
            CreateMap<CreateCategoryInput, Category>();
            CreateMap<Category, CategoryModelOutput>();

            //User
            CreateMap<CreateUserInput, User>();
            CreateMap<User, UserModelOutput>();
            CreateMap<User, UserAuthenticateModelOutput>().ReverseMap();

            //Transaction
            CreateMap<CreateTransactionInput, Transaction>();
            CreateMap<Transaction, TransactionModelOutput>();
            CreateMap<Transaction, TransactionDetailsModelOutput>();
        }
    }
}
