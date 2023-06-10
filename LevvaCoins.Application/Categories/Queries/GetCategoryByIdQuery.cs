using LevvaCoins.Domain.Entities;
using MediatR;

namespace LevvaCoins.Application.Categories.Queries
{
    public class GetCategoryByIdQuery : IRequest<Category?>
    {
        public Guid Id { get; set; }

        public GetCategoryByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
