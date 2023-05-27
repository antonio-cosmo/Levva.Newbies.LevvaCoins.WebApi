using AutoMapper;
using LevvaCoins.Application.Transactions.Commands;
using LevvaCoins.Application.Transactions.Dtos;
using LevvaCoins.Domain.Common;
using LevvaCoins.Domain.Entities;

namespace LevvaCoins.Application.Transactions.Mapper
{
    public class TransactionProfile: Profile
    {
        public TransactionProfile()
        {
            CreateMap<CreateTransactionDto, CreateTransactionCommand>().ReverseMap();
            CreateMap<UpdateTransactionDto, UpdateTransactionCommand>().ReverseMap();
            CreateMap<CreateTransactionCommand, Transaction>().ReverseMap();
            CreateMap<UpdateTransactionCommand, Transaction>().ReverseMap();
            CreateMap<PagedResult<Transaction>, PagedResult<TransactionViewDto>>().ReverseMap();
            CreateMap<Transaction, TransactionViewDto>().ReverseMap();
        }
    }
}
