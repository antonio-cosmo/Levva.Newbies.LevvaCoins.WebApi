using LevvaCoins.Application.Services.Dtos.Category;
using MediatR;

namespace LevvaCoins.Application.UseCases.Categories.GetCategory
{
    public class GetCategory : IRequest<CategoryModelResponse>
    {
        public Guid Id { get; set; }

        public GetCategory(Guid id)
        {
            Id = id;
        }
    }
}
