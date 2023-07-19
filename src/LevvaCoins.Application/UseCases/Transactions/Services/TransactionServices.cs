using AutoMapper;
using LevvaCoins.Application.UseCases.Transactions.Commands;
using LevvaCoins.Application.UseCases.Transactions.Dtos;
using LevvaCoins.Application.UseCases.Transactions.Interfaces;
using LevvaCoins.Domain.Common;
using MediatR;

namespace LevvaCoins.Application.UseCases.Transactions.Services
{
    public class TransactionServices : ITransactionServices
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public TransactionServices(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public async Task<TransactionDetailsDto> SaveAsync(Guid userId, CreateTransactionDto createTransactionDto)
        {
            //var saveCommand = GetInstanceSaveTransactionCommand(userId, createTransactionDto);
            //var transaction = await _mediator.Send(saveCommand);

            //return _mapper.Map<TransactionDetailsDto>(transaction);
            throw new NotImplementedException();
        }
        public async Task RemoveAsync(Guid id)
        {
            var removeCommand = new RemoveTransactionCommand(id);
            await _mediator.Send(removeCommand);
        }
        public async Task<IEnumerable<TransactionDetailsDto>> GetAllAsync(Guid userId)
        {
            //var queryAll = new GetAllTransactionsByUserQuery(userId);
            //var transactions = await _mediator.Send(queryAll);

            //return _mapper.Map<IEnumerable<TransactionDetailsDto>>(transactions);
            throw new NotImplementedException();

        }
        public async Task<TransactionDetailsDto> GetByIdAsync(Guid id)
        {
            //var queryById = new GetTransactionByIdQuery(id);
            //var transaction = await _mediator.Send(queryById) ?? throw new ModelNotFoundException("Essa transação não existe.");

            //return _mapper.Map<TransactionDetailsDto>(transaction);
            throw new NotImplementedException();
        }
        public async Task<PagedResult<TransactionDetailsDto>> GetAllPagedAsync(Guid userId, PaginationOptions paginationOptions)
        {
            //var queryByUserId = new GetAllTransactionByUserPagedQuery(userId, paginationOptions);
            //var transactionsPaged = await _mediator.Send(queryByUserId);

            //return _mapper.Map<PagedResult<TransactionDetailsDto>>(transactionsPaged);
            throw new NotImplementedException();

        }
        public async Task UpdateAsync(Guid id, UpdateTransactionDto updateTransactionDto)
        {
            var updateCommand = GetInstanceUpdateTransactionCommand(id, updateTransactionDto);

            await _mediator.Send(updateCommand);
        }
        public async Task<IEnumerable<TransactionDetailsDto>> SearchByDescriptionAsync(Guid userId, string search)
        {
            //var queryByDescription = new SearchAllTransactionByUserAndDescriptionQuery(userId, search);
            //var transactions = await _mediator.Send(queryByDescription);

            //return _mapper.Map<IEnumerable<TransactionDetailsDto>>(transactions);
            throw new NotImplementedException();

        }
        private static SaveTransactionCommand GetInstanceSaveTransactionCommand(Guid userId, CreateTransactionDto createTransactionDto)
        {
            var description = createTransactionDto.Description
                ?? throw new NullReferenceException(nameof(createTransactionDto.Description));

            return new SaveTransactionCommand(
                    userId,
                    description,
                    createTransactionDto.Amount,
                    createTransactionDto.Type,
                    createTransactionDto.CategoryId
                );
        }
        private static UpdateTransactionCommand GetInstanceUpdateTransactionCommand(Guid id, UpdateTransactionDto updateTransactionDto)
        {
            var description = updateTransactionDto.Description
                ?? throw new NullReferenceException(nameof(updateTransactionDto.Description));

            return new UpdateTransactionCommand(
                    id,
                    description,
                    updateTransactionDto.Amount,
                    updateTransactionDto.Type,
                    updateTransactionDto.CategoryId
                );

        }
    }
}
