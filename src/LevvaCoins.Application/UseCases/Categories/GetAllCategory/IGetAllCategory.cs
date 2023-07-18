using LevvaCoins.Application.UseCases.Categories.Common;
using MediatR;

namespace LevvaCoins.Application.UseCases.Categories.GetAllCategory;
public interface IGetAllCategory : IRequestHandler<GetAllCategoryInput, IEnumerable<CategoryOutput>>
{
}
