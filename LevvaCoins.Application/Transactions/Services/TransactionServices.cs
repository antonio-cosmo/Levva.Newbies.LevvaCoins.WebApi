using AutoMapper;
using LevvaCoins.Application.Transactions.Commands;
using LevvaCoins.Application.Transactions.Dtos;
using LevvaCoins.Application.Transactions.Interfaces;
using LevvaCoins.Application.Transactions.Queries;
using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Common;
using LevvaCoins.Domain.Common.Dtos;
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

        public async Task CreateTransactionAsync(CreateTransactionDto transaction, Guid userId)
        {
            var command = new CreateTransactionCommand(transaction.Description, transaction.Amount, transaction.Type, transaction.CategoryId, userId);
            await _mediator.Send(command);
        }

        public async Task DeleteByIdTransaction(Guid transactionId)
        {
            var command = new DeleteTransactionCommand(transactionId);
            await _mediator.Send(command);
        }

        public async Task<TransactionDto> GetByIdTransaction(Guid transactionId)
        {
            var query = new GetTransactionByIdQuery(transactionId);
            var result = await _mediator.Send(query); 

            if (result is null) throw new ModelNotFoundException("Essa transação não existe.");

            return _mapper.Map<TransactionDto>(result);
        }

        public async Task<IEnumerable<TransactionDto>> SearchTransactionByDescription(string search)
        {
            var query = new GetTransactionByDescriptionQuery(search);
            var result = await _mediator.Send(query);
            return _mapper.Map<IEnumerable<TransactionDto>>(result);
        }

        public async Task<PagedResultDto<TransactionDto>> SearchTransactionByUser(Guid userId, PaginationOptions paginationOptions)
        {
            var query = new GetTransactionByUserIdQuery(userId, paginationOptions);
            var result = await _mediator.Send(query);

            return _mapper.Map<PagedResultDto<TransactionDto>>(result);
        }

        public async Task UpdateTransaction(Guid id, UpdateTransactionDto transaction)
        {
            var command = new UpdateTransactionCommand(id, transaction.Description, transaction.Amount, transaction.Type, transaction.CategoryId);
            await _mediator.Send(command);
        }
    }
}
