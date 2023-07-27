using LevvaCoins.Application.UseCases.Categories.Common;
using MediatR;

namespace LevvaCoins.Application.UseCases.Categories.GetCategory;
public interface IGetCategory : IRequestHandler<GetCategoryInput, CategoryModelOutput>
{
}
