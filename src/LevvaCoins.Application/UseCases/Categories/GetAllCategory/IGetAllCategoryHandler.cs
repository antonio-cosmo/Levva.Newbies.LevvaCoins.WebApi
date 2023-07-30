using LevvaCoins.Application.Services.Dtos.Category;
using MediatR;

namespace LevvaCoins.Application.UseCases.Categories.GetAllCategory;
public interface IGetAllCategoryHandler : IRequestHandler<GetAllCategory, IEnumerable<CategoryModelResponse>>
{
}
