using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevvaCoins.Application.Categories.Queries;
using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Repositories;
using MediatR;

namespace LevvaCoins.Application.Categories.Handlers
{
    class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Category?>
    {
        readonly ICategoryRepository _categoryRepository;

        public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken) =>
            await _categoryRepository.GetAsync(request.Id);
    }
}
