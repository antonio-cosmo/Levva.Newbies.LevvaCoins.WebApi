using LevvaCoins.Application.Responses;
using MediatR;

namespace LevvaCoins.Application.Queries.Requests.Category;

public class GetAllCategoryRequest : IRequest<IEnumerable<CategoryModelResponse>>
{
}