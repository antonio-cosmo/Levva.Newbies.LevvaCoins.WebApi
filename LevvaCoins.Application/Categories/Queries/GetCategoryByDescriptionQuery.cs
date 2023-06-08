using LevvaCoins.Domain.Entities;
using LevvaCoins.Domain.Interfaces.Repositories;
using MediatR;

namespace LevvaCoins.Application.Categories.Queries
{
    public class GetCategoryByDescriptionQuery:IRequest<Category?>
    {
        public string Description { get; set; }

        public GetCategoryByDescriptionQuery(string description)
        {
            Description = description;
        }
    }
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
