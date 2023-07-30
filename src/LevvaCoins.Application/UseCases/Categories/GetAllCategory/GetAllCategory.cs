using LevvaCoins.Application.Services.Dtos.Category;
using MediatR;

namespace LevvaCoins.Application.UseCases.Categories.GetAllCategory;
public class GetAllCategory : IRequest<IEnumerable<CategoryModelResponse>>
{
}
