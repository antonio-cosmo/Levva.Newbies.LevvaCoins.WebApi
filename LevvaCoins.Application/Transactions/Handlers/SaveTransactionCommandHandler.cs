using AutoMapper;
using LevvaCoins.Application.Transactions.Commands;
using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Interfaces.Repositories;
using MediatR;

namespace LevvaCoins.Application.Transactions.Handlers
{
    public class SaveTransactionCommandHandler : IRequestHandler<SaveTransactionCommand, Transaction>
    {
        readonly ITransactionRepository _transactionRepository;
        readonly IMapper _mapper;

        public SaveTransactionCommandHandler(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<Transaction> Handle(SaveTransactionCommand request, CancellationToken cancellationToken)
        {
            var newTransaction = _mapper.Map<Transaction>(request);
            ValidateTransaction(newTransaction);

            return await _transactionRepository.SaveAsync(newTransaction);
        }
        private static void ValidateTransaction(Transaction transaction)
        {
            if (!transaction.IsValid())
            {
                throw new DomainValidationException("Entidade invalida.");
            }
        }
    }
}
