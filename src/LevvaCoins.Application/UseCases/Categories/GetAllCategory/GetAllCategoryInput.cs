using LevvaCoins.Application.UseCases.Categories.Common;
using MediatR;

namespace LevvaCoins.Application.UseCases.Categories.GetAllCategory;
public class GetAllCategoryInput : IRequest<IEnumerable<CategoryOutput>>
{
}
