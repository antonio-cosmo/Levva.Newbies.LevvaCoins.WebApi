using AutoMapper;
using LevvaCoins.Application.Services.Dtos.Category;
using LevvaCoins.Application.Services.Dtos.User;
using LevvaCoins.Application.UseCases.Categories.CreateCategory;
using LevvaCoins.Application.UseCases.Transactions.Common;
using LevvaCoins.Application.UseCases.Transactions.CreateTransaction;
using LevvaCoins.Application.UseCases.Users.CreateUser;
using LevvaCoins.Domain.Entities;

namespace LevvaCoins.Application.MapperProfiles
{
    public class DefaultMapper : Profile
    {
        public DefaultMapper()
        {
            //Category
            CreateMap<CreateCategory, Category>();
            CreateMap<Category, CategoryModelResponse>();

            //User
            CreateMap<CreateUser, User>();
            CreateMap<User, UserModelResponse>();
            CreateMap<User, UserAuthenticateModelResponse>().ReverseMap();

            //Transaction
            CreateMap<CreateTransaction, Transaction>();
            CreateMap<Transaction, TransactionModelResponse>();
            CreateMap<Transaction, TransactionDetailsModelResponse>();
        }
    }
}
