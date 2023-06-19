using AutoMapper;
using LevvaCoins.Application.Transactions.Commands;
using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Interfaces.Repositories;
using MediatR;

namespace LevvaCoins.Application.Transactions.Handlers
{
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
            try
            {
                var transactionExists = await _transactionRepository.GetByIdAsync(request.Id)
                    ?? throw new ModelNotFoundException("Essa transação não existe");

                transactionExists.Update(
                        request.Description,
                        request.Amount,
                        request.Type,
                        request.CategoryId
                    );
                transactionExists.Validate();
                await _transactionRepository.UpdateAsync(transactionExists);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
