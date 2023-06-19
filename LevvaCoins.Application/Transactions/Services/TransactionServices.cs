using AutoMapper;
using LevvaCoins.Application.Transactions.Commands;
using LevvaCoins.Application.Transactions.Dtos;
using LevvaCoins.Application.Transactions.Interfaces;
using LevvaCoins.Application.Transactions.Queries;
using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Common;
using MediatR;
using Microsoft.IdentityModel.Tokens;

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

        public async Task<TransactionDetailsDto> SaveAsync(Guid userId, CreateTransactionDto createTransactionDto)
        {
            var saveCommand = new SaveTransactionCommand(
                userId,
                description: createTransactionDto.Description
                                                ?? throw new ArgumentException("Descrição vazia", nameof(createTransactionDto.Description)),
                amount: createTransactionDto.Amount, createTransactionDto.Type,
                categoryId: createTransactionDto.CategoryId
            );

            var transaction = await _mediator.Send(saveCommand);

            return _mapper.Map<TransactionDetailsDto>( transaction );
        }

        public async Task RemoveAsync(Guid id)
        {
            var removeCommand = new RemoveTransactionCommand(id);
            await _mediator.Send(removeCommand);
        }

        public async Task<IEnumerable<TransactionDetailsDto>> GetAllAsync(Guid userId)
        {
            var queryAll = new GetAllTransactionsByUserQuery(userId);
            var transactions =  await _mediator.Send(queryAll);

            return _mapper.Map<IEnumerable<TransactionDetailsDto>>(transactions);
        }

        public async Task<TransactionDetailsDto> GetByIdAsync(Guid id)
        {
            var queryById = new GetTransactionByIdQuery(id);

            var transaction = await _mediator.Send(queryById)
                ?? throw new ModelNotFoundException("Essa transação não existe.");

            return _mapper.Map<TransactionDetailsDto>(transaction);
        }

        public async Task<PagedResult<TransactionDetailsDto>> GetAllPagedAsync(Guid userId, PaginationOptions paginationOptions)
        {
            var queryByUserId = new GetAllTransactionByUserPagedQuery(userId, paginationOptions);
            var transactionsPaged = await _mediator.Send(queryByUserId);

            return _mapper.Map<PagedResult<TransactionDetailsDto>>(transactionsPaged);
        }

        public async Task UpdateAsync(Guid id, UpdateTransactionDto updateTransactionDto)
        {
            var updateCommand = new UpdateTransactionCommand(
                id,
                description: updateTransactionDto.Description
                                        ?? throw new ArgumentException("Descrição vazia",nameof(updateTransactionDto.Description)),
                amount: updateTransactionDto.Amount,
                type: updateTransactionDto.Type,
                categoryId: updateTransactionDto.CategoryId
            );

            await _mediator.Send(updateCommand);
        }
        public async Task<IEnumerable<TransactionDetailsDto>> SearchByDescriptionAsync(Guid userId, string search)
        {
            var queryByDescription = new SearchAllTransactionByUserAndDescriptionQuery(userId, search);
            var transactions = await _mediator.Send(queryByDescription);

            return _mapper.Map<IEnumerable<TransactionDetailsDto>>(transactions);

        }

    }
}
