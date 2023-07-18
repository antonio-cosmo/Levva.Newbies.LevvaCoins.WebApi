using AutoMapper;
using LevvaCoins.Application.UseCases.Transactions.Commands;
using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Repositories;
using MediatR;

namespace LevvaCoins.Application.UseCases.Transactions.Handlers
{
    public class SaveTransactionCommandHandler : IRequestHandler<SaveTransactionCommand>
    {
        readonly ITransactionRepository _transactionRepository;
        readonly IMapper _mapper;

        public SaveTransactionCommandHandler(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task Handle(SaveTransactionCommand request, CancellationToken cancellationToken)
        {
            var newTransaction = _mapper.Map<Transaction>(request);

            await _transactionRepository.InsertAsync(newTransaction, cancellationToken);
        }
    }
}
