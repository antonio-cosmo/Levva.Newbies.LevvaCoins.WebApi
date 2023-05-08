using AutoMapper;
using LevvaCoins.Application.Transactions.Dtos;
using LevvaCoins.Domain.Entities;

namespace LevvaCoins.Application.Transactions.Mapper
{
    public class TransactionProfile: Profile
    {
        public TransactionProfile()
        {
            CreateMap<CreateTransactionDto, Transaction>();
            CreateMap<UpdateTransactionDto, Transaction>();
            CreateMap<Transaction, TransactionDto>();
        }
    }
}
