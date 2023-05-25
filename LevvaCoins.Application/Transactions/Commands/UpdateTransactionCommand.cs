using AutoMapper;
using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Enums;
using LevvaCoins.Domain.Interfaces.Repositories;
using MediatR;

namespace LevvaCoins.Application.Transactions.Commands
{
    public class UpdateTransactionCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public double Amount { get; set; }
        public TransactionTypeEnum Type { get; set; }
        public Guid CategoryId { get; set; }

        public UpdateTransactionCommand(Guid id, string description, double amount, TransactionTypeEnum type, Guid categoryId)
        {
            Id = id;
            Description = description;
            Amount = amount;
            Type = type;
            CategoryId = categoryId;
        }
    }

    public class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand>
    {
        readonly ITransactionRepository _transactionRepository;
        readonly IMapper _mapper;

        public UpdateTransactionCommandHandler(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transactioAreadyExists = await _transactionRepository.GetByIdAsync(request.Id);
            if (transactioAreadyExists is null) throw new ModelNotFoundException("Essa transação não existe");

            transactioAreadyExists.Update(
                    request.Description,
                    request.Amount,
                    request.Type,
                    request.CategoryId
                );

            await _transactionRepository.UpdateAsync(transactioAreadyExists);
        }
    }
}
