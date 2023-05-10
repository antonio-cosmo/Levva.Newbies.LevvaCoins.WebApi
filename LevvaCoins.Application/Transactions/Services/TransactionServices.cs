using AutoMapper;
using LevvaCoins.Application.Transactions.Dtos;
using LevvaCoins.Application.Transactions.Interfaces;
using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Common;
using LevvaCoins.Domain.Common.Dtos;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Interfaces.Repositories;

namespace LevvaCoinsApi.Application.Transactions.Services
{
    public class TransactionServices : ITransactionServices
    {
        readonly ITransactionRepository _transactionRepository;
        readonly IMapper _mapper;
        public TransactionServices(
            ITransactionRepository transactionRepository, 
            IMapper mapper
        )
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task CreateTransactionAsync(CreateTransactionDto transactionDto, string userId)
        {

            var transaction = _mapper.Map<Transaction>( transactionDto );
            transaction.UserId = new Guid(userId);

            await _transactionRepository.SaveAsync(transaction);
        }

        public async Task DeleteByIdTransaction(Guid transactionId)
        {
            var success = await _transactionRepository.DeleteByIdAsync(transactionId);
            if (!success) throw new ModelNotFoundException("Essa transação não existe.");
        }

        public async Task<IEnumerable<TransactionDto>> GetAllTransactionsAsync()
        {
            var transactionList = await _transactionRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<TransactionDto>>(transactionList);
        }

        public async Task<PagedResultDto<TransactionDto>> GetAllTransactionsAsync(PaginationOptions paginationOptions)
        {
            var result = await _transactionRepository.GetAllTransactions(paginationOptions);
            //var transactions = _mapper.Map<IEnumerable<TransactionDto>>(result.Items);

            return _mapper.Map<PagedResultDto<TransactionDto>>(result);

        }

        public async Task<TransactionDto> GetByIdTransaction(Guid transactionId)
        {
            var transaction = await _transactionRepository.GetByIdAsync(transactionId);
            if (transaction == null) throw new ModelNotFoundException("Essa transação não existe.");

            return _mapper.Map<TransactionDto>(transaction);
        }

        public async Task<IEnumerable<TransactionDto>> SearchTransactionByuser(Guid userId)
        {
            var transactionList = await _transactionRepository.GetTransactionByUser(userId);

            return _mapper.Map<IEnumerable<TransactionDto>>(transactionList);
        }

        public async Task UpdateTransaction(Guid id, UpdateTransactionDto transactionDto)
        {
            var transactioAreadyExists = await _transactionRepository.GetByIdAsync(id);
            if (transactioAreadyExists == null) throw new ModelNotFoundException("Essa transação não existe");

            transactioAreadyExists.Description = transactionDto.Description;
            transactioAreadyExists.Amount = transactionDto.Amount;
            transactioAreadyExists.Type = transactionDto.Type;
            transactioAreadyExists.CategoryId = transactionDto.CategoryId;

            await _transactionRepository.UpdateAsync(transactioAreadyExists);
        }
    }
}
