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
            CreateMap<CreateTransactionDto, SaveTransactionCommand>().ReverseMap();
            CreateMap<SaveTransactionCommand, Transaction>().ReverseMap();
            CreateMap<UpdateTransactionCommand, Transaction>().ReverseMap();
            CreateMap<PagedResult<Transaction>, PagedResult<TransactionDetailsDto>>().ReverseMap();
            CreateMap<Transaction, TransactionDetailsDto>().ReverseMap();
        }
    }
}
