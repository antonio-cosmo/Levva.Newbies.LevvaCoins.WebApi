using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevvaCoins.Application.Categories.Queries;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Interfaces.Repositories;
using MediatR;

namespace LevvaCoins.Application.Categories.Handlers
{
    public class GetCategoryByDescriptionQueryHandler : IRequestHandler<GetCategoryByDescriptionQuery, Category?>
    {
        readonly ICategoryRepository _categoryRepository;

        public GetCategoryByDescriptionQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category?> Handle(GetCategoryByDescriptionQuery request, CancellationToken cancellationToken)
        {

            return await _categoryRepository.GetByDescriptionAsync(request.Description);

        }
    }
}
