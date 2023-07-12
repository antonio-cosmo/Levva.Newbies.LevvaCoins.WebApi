using LevvaCoins.Domain.Entities;
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
}
