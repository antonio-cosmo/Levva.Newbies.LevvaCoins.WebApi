using LevvaCoins.Domain.Entities;
using MediatR;

namespace LevvaCoins.Application.Categories.Queries
{
    public class GetAllCategoryQuery : IRequest<IEnumerable<Category>>
    {
    }
}
