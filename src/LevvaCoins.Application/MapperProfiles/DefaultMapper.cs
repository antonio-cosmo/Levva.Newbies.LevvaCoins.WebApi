using AutoMapper;
using LevvaCoins.Application.Commands.Requests.Transaction;
using LevvaCoins.Application.Responses;
using LevvaCoins.Domain.Entities;

namespace LevvaCoins.Application.MapperProfiles;

public class DefaultMapper : Profile
{
    public DefaultMapper()
    {
        //Category
        // CreateMap<CreateCategory, Category>();
        // CreateMap<Category, CategoryModelResponse>();

        //User
        // CreateMap<CreateUser, User>();
        CreateMap<User, UserModelResponse>();
        CreateMap<User, UserAuthenticateModelResponse>().ReverseMap();

        //Transaction
        CreateMap<CreateTransactionRequest, Transaction>();
        CreateMap<Transaction, TransactionModelResponse>();
        CreateMap<Transaction, TransactionDetailsModelResponse>();
    }
}