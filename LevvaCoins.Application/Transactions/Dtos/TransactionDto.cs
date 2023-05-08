﻿using LevvaCoins.Domain.Enums;

namespace LevvaCoins.Application.Transactions.Dtos
{
    public class TransactionDto
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public double Amount { get; set; }
        public TransactionTypeEnum Type { get; set; }
        public Guid CategoryId { get; set; }
    }
}