using LevvaCoins.Application.Services.Dtos.Category;
using MediatR;

namespace LevvaCoins.Application.UseCases.Categories.GetCategory;
public interface IGetCategoryHandler : IRequestHandler<GetCategory, CategoryModelResponse>
{
}
