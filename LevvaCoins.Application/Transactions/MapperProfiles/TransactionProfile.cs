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
            CreateMap<SaveTransactionDto, SaveTransactionCommand>().ReverseMap();
            CreateMap<UpdateTransactionDto, UpdateTransactionCommand>().ReverseMap();
            CreateMap<SaveTransactionCommand, Transaction>().ReverseMap();
            CreateMap<UpdateTransactionCommand, Transaction>().ReverseMap();
            CreateMap<PagedResult<Transaction>, PagedResult<TransactionViewDto>>().ReverseMap();
            CreateMap<Transaction, TransactionViewDto>().ReverseMap();
        }
    }
}
