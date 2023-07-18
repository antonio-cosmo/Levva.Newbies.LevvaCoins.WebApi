using LevvaCoins.Application.UseCases.Categories.Common;
using LevvaCoins.Domain.Entities;
using MediatR;

namespace LevvaCoins.Application.UseCases.Categories.GetCategory
{
    public class GetCategoryInput : IRequest<CategoryOutput>
    {
        public Guid Id { get; set; }

        public GetCategoryInput(Guid id)
        {
            Id = id;
        }
    }
}
