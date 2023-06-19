using AutoMapper;
using LevvaCoins.Application.Transactions.Commands;
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
            try
            {
                var transaction = _mapper.Map<Transaction>(request);
                transaction.Validate();

                return await _transactionRepository.SaveAsync(transaction);
            }catch (Exception)
            {
                throw;
            }
        }
    }
}
