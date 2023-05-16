﻿using AutoMapper;
using LevvaCoins.Application.Transactions.Commands;
using LevvaCoins.Application.Transactions.Dtos;
using LevvaCoins.Domain.Common.Dtos;
using LevvaCoins.Domain.Entities;

namespace LevvaCoins.Application.Transactions.Mapper
{
    public class TransactionProfile: Profile
    {
        public TransactionProfile()
        {
            CreateMap<CreateTransactionDto, Transaction>();
            CreateMap<CreateTransactionDto, CreateTransactionCommand>();
            CreateMap<CreateTransactionCommand, Transaction>();
            CreateMap<UpdateTransactionDto, Transaction>();
            CreateMap<PagedResultDto<Transaction>, PagedResultDto<TransactionDto>>();
            CreateMap<Transaction, TransactionDto>();
        }
    }
}
