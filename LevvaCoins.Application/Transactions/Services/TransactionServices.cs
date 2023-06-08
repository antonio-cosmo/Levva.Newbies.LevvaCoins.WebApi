using AutoMapper;
using LevvaCoins.Application.Transactions.Commands;
using LevvaCoins.Application.Transactions.Dtos;
using LevvaCoins.Application.Transactions.Interfaces;
using LevvaCoins.Application.Transactions.Queries;
using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Common;
using MediatR;

namespace LevvaCoins.Application.Transactions.Services
{
    public class TransactionServices : ITransactionServices
    {
        readonly IMediator _mediator;
        readonly IMapper _mapper;
        public TransactionServices(
            IMediator mediator,
            IMapper mapper
        )
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<TransactionViewDto> CreateTransactionAsync(CreateTransactionDto transactionDto, Guid userId)
        {   
            
            var command = new CreateTransactionCommand(transactionDto.Description, transactionDto.Amount, transactionDto.Type, transactionDto.CategoryId, userId);
            var transaction = await _mediator.Send(command);

            return _mapper.Map<TransactionViewDto>( transaction );
        }

        public async Task DeleteByIdTransaction(Guid transactionId)
        {
            var command = new DeleteTransactionCommand(transactionId);
            await _mediator.Send(command);
        }

        public async Task<IEnumerable<TransactionViewDto>> GetAllTransactions(Guid userId)
        {
            var transactions =  await _mediator.Send(new GetAllTransactionsQuery(userId));

            return _mapper.Map<IEnumerable<TransactionViewDto>>(transactions);
        }

        public async Task<TransactionViewDto> GetByIdTransaction(Guid transactionId)
        {
            var query = new GetTransactionByIdQuery(transactionId);
            var result = await _mediator.Send(query); 

            if (result is null) throw new ModelNotFoundException("Essa transação não existe.");

            return _mapper.Map<TransactionViewDto>(result);

        }

        public async Task<IEnumerable<TransactionViewDto>> SearchTransactionByDescription(Guid userId, string search)
        {
            var query = new GetTransactionByDescriptionQuery(userId,search);
            var result = await _mediator.Send(query);

            return _mapper.Map<IEnumerable<TransactionViewDto>>(result);

        }

        public async Task<PagedResult<TransactionViewDto>> SearchTransactionByUser(Guid userId, PaginationOptions paginationOptions)
        {
            var query = new GetTransactionByUserIdQuery(userId, paginationOptions);
            var result = await _mediator.Send(query);

            return _mapper.Map<PagedResult<TransactionViewDto>>(result!);
        }

        public async Task UpdateTransaction(Guid id, UpdateTransactionDto transaction)
        {
            var command = new UpdateTransactionCommand(id, transaction.Description, transaction.Amount, transaction.Type, transaction.CategoryId);
            await _mediator.Send(command);
        }
    }
}
