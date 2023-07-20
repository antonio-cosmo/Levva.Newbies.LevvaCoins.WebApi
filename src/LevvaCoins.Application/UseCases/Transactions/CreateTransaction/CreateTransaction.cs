using AutoMapper;
using LevvaCoins.Application.UseCases.Categories.GetCategory;
using LevvaCoins.Application.UseCases.Transactions.Common;
using LevvaCoins.Application.UseCases.Transactions.GetTransaction;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Repositories;
using LevvaCoins.Domain.SeedWork;
using MediatR;

namespace LevvaCoins.Application.UseCases.Transactions.CreateTransaction;

public class CreateTransaction : ICreateTransaction
{
    readonly ITransactionRepository _transactionRepository;
    readonly ICategoryRepository _categoryRepository;
    readonly IUnitOfWork _unitOfWork;
    readonly IMapper _mapper;

    public CreateTransaction(ITransactionRepository transactionRepository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository,IMapper mapper)
    {
        _transactionRepository = transactionRepository;
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<TransactionDetailsOutput> Handle(CreateTransactionInput request, CancellationToken cancellationToken)
    {
        var newTransaction = _mapper.Map<Transaction>(request);

        await _transactionRepository.InsertAsync(newTransaction, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
        newTransaction.Category = await _categoryRepository.GetAsync(request.CategoryId, cancellationToken);

        return TransactionDetailsOutput.FromModel(newTransaction);
    }
}
