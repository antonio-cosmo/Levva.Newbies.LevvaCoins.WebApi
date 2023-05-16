using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LevvaCoins.Domain.AppExceptions;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Interfaces.Repositories;
using MediatR;

namespace LevvaCoins.Application.Categories.Commands
{
    public class UpdateCategoryCommand : IRequest
    {
        public string Description { get; set; } = string.Empty;
        public Guid Id { get; set; }

        public UpdateCategoryCommand(string description, Guid id)
        {
            Description = description;
            Id = id;
        }
    }

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryAlreadExist = await _categoryRepository.GetByIdAsync(request.Id);
            if(categoryAlreadExist is null) throw new ModelNotFoundException("Essa categoria não existe.");

            categoryAlreadExist.Update(request.Description);
            await _categoryRepository.UpdateAsync(categoryAlreadExist);
        }
    }
}
