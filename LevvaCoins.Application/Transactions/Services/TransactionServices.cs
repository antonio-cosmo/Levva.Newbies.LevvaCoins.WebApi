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

        public async Task<TransactionViewDto> SaveAsync(SaveTransactionDto transactionDto, Guid userId)
        {   
            
            var saveCommand = new SaveTransactionCommand(transactionDto.Description, transactionDto.Amount, transactionDto.Type, transactionDto.CategoryId, userId);
            var transaction = await _mediator.Send(saveCommand);

            return _mapper.Map<TransactionViewDto>( transaction );
        }

        public async Task RemoveAsync(Guid transactionId)
        {
            var removeCommand = new RemoveTransactionCommand(transactionId);
            await _mediator.Send(removeCommand);
        }

        public async Task<IEnumerable<TransactionViewDto>> GetAllAsync(Guid userId)
        {
            var queryAll = new GetAllTransactionsQuery(userId);
            var transactions =  await _mediator.Send(queryAll);

            return _mapper.Map<IEnumerable<TransactionViewDto>>(transactions);
        }

        public async Task<TransactionViewDto> GetByIdAsync(Guid transactionId)
        {
            var queryById = new GetTransactionByIdQuery(transactionId);
            var transaction = await _mediator.Send(queryById); 

            if (transaction is null) throw new ModelNotFoundException("Essa transação não existe.");

            return _mapper.Map<TransactionViewDto>(transaction);

        }

        public async Task<IEnumerable<TransactionViewDto>> SearchByDescriptionAsync(Guid userId, string search)
        {
            var queryByDescription = new GetTransactionByDescriptionQuery(userId,search);
            var transactions = await _mediator.Send(queryByDescription);

            return _mapper.Map<IEnumerable<TransactionViewDto>>(transactions);

        }

        public async Task<PagedResult<TransactionViewDto>> SearchByUserIdAsync(Guid userId, PaginationOptions paginationOptions)
        {
            var queryByUserId = new GetTransactionByUserIdQuery(userId, paginationOptions);
            var transactionsPaged = await _mediator.Send(queryByUserId);

            return _mapper.Map<PagedResult<TransactionViewDto>>(transactionsPaged);
        }

        public async Task UpdateAsync(Guid id, UpdateTransactionDto transaction)
        {
            var updateCommand = new UpdateTransactionCommand(id, transaction.Description, transaction.Amount, transaction.Type, transaction.CategoryId);
            await _mediator.Send(updateCommand);
        }
    }
}
