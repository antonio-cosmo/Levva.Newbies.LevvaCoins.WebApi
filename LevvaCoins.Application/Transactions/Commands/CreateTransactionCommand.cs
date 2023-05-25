using AutoMapper;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Enums;
using LevvaCoins.Domain.Interfaces.Repositories;
using MediatR;

namespace LevvaCoins.Application.Transactions.Commands
{
    public class CreateTransactionCommand: IRequest
    {
        public string Description { get; set; } = string.Empty;
        public double Amount { get; set; }
        public TransactionTypeEnum Type { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }

        public CreateTransactionCommand(string description, double amount, TransactionTypeEnum type, Guid categoryId, Guid userId)
        {
            Description = description;
            Amount = amount;
            Type = type;
            CategoryId = categoryId;
            UserId = userId;
        }
    }

    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand>
    {
        readonly ITransactionRepository _transactionRepository;
        readonly IMapper _mapper;

        public CreateTransactionCommandHandler(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = _mapper.Map<Transaction>(request);
            await _transactionRepository.SaveAsync(transaction);
        }
    }
}
